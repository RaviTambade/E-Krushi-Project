using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text;
using Transflower.EKrushi.Orders.Repositories.Interfaces;
using Transflower.EKrushi.Orders.Repositories.Contexts;
using Transflower.EKrushi.Orders.Models;
using Transflower.EKrushi.Orders.Entities;

namespace Transflower.EKrushi.Orders.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderRepository(OrderContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<OrderAmount> CreateOrder(OrderAddModel orderAddModel)
    {
        int fetchStoreId = await GetNearestStoreId(orderAddModel.AddressId);
        Console.WriteLine($" --> {fetchStoreId}");

        Order order = new Order()
        {
            Id = 0,
            CustomerId = orderAddModel.CustomerId,
            AddressId = orderAddModel.AddressId,
            Status = "initiated",
            Total = 0,
            StoreId = fetchStoreId != default ? fetchStoreId : 1
        };
        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            int orderId = order.Id;
            if (orderAddModel.OrderDetails != null)
                foreach (var item in orderAddModel.OrderDetails)
                {
                    var productDetailsId = await _context.ProductDetails
                        .Where(p => p.ProductId == item.ProductId && p.Size == item.Size)
                        .Select(p => p.Id)
                        .FirstOrDefaultAsync();
                    if (productDetailsId == default)
                    {
                        continue;
                    }

                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderId = orderId,
                        ProductDetailsId = productDetailsId,
                        Quantity = item.Quantity,
                    };

                    await _context.AddAsync(orderDetail);
                    ProductDetail? productDetails = await _context.ProductDetails.FindAsync(
                        productDetailsId
                    );
                    if (productDetails != null)
                    {
                        productDetails.StockAvailable =
                            productDetails.StockAvailable - item.Quantity;
                        _context.Entry(productDetails).State = EntityState.Modified;
                    }
                }
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            var total = await (
                from od in _context.OrderDetails
                where od.OrderId == orderId
                join pd in _context.ProductDetails on od.ProductDetailsId equals pd.Id
                select pd.UnitPrice * od.Quantity
            ).SumAsync();
            var order1 = await _context.Orders.FindAsync(orderId);
            if (order1 != null)
            {
                order1.Total = total;
                await _context.SaveChangesAsync();
            }

            return new OrderAmount { OrderId = orderId, Amount = total };
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<double> GetOrderAmount(int orderId)
    {
        try
        {
            var amount = await _context.Orders
                .Where(o => o.Id == orderId)
                .Select(o => o.Total)
                .FirstAsync();
            return amount;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<CustomerOrder>> GetCustomerOrderDetails(int customerId)
    {
        try
        {
            var orders = await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Select(
                    o =>
                        new CustomerOrder()
                        {
                            Id = o.Id,
                            OrderDate = o.OrderDate,
                            ShippedDate = o.ShippedDate,
                            Status = o.Status,
                            Total = o.Total
                        }
                )
                .ToListAsync();
            return orders;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> RemoveOrder(int orderId)
    {
        bool status = false;
        try
        {
            Order? order = await _context.Orders.FindAsync(orderId);
            if (order is not null)
            {
                _context.Orders.Remove(order);
                status = await SaveChanges(_context);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    private async Task<bool> SaveChanges(OrderContext context)
    {
        int rowsAffected = await context.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<List<OrderDetailModel>> GetOrderDetails(int orderId)
    {
        try
        {
            var orderDetails = await (
                from product in _context.Products
                join productDetail in _context.ProductDetails
                    on product.Id equals productDetail.ProductId
                join orderDetail in _context.OrderDetails
                    on productDetail.Id equals orderDetail.ProductDetailsId
                join order in _context.Orders on orderDetail.OrderId equals order.Id
                where order.Id == orderId
                select new OrderDetailModel()
                {
                    ProductId = product.Id,
                    Size = productDetail.Size,
                    UnitPrice = productDetail.UnitPrice,
                    Image = product.Image,
                    Title = product.Title,
                    Quantity = orderDetail.Quantity,
                    Total = productDetail.UnitPrice * orderDetail.Quantity
                }
            ).ToListAsync();

            return orderDetails;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> GetAddressIdOfOrder(int orderId)
    {
        try
        {
            var addressId = await _context.Orders
                .Where(o => o.Id == orderId)
                .Select(o => o.AddressId)
                .FirstAsync();
            return addressId;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<int> GetNearestStoreId(int customerAddressId)
    {
        try
        {
            int addressId = await GetNearestStoreAddressId(customerAddressId);
            if (addressId == default)
            {
                return default;
            }
            var storeId = await _context.Stores
                .Where(store => store.AddressId == addressId)
                .Select(store => store.Id)
                .FirstOrDefaultAsync();
            return storeId;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<int> GetNearestStoreAddressId(int customerAddressId)
    {
        try
        {
            string addressIdsAsString = await GetAddressIdOfStores();
            var body = new
            {
                addressId = customerAddressId,
                storeAddressIdString = addressIdsAsString
            };
            string jsonBody = JsonSerializer.Serialize(body);
            var requestContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            string requestUrl = "http://localhost:5102/api/addresses/nearest";

            HttpClient httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsync(requestUrl, requestContent);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                int addressId = JsonSerializer.Deserialize<int>(apiResponse);
                return addressId;
            }
        }
        catch (Exception)
        {
            throw;
        }
        return default;
    }

    private async Task<string> GetAddressIdOfStores()
    {
        try
        {
            var addressIds = await _context.Stores.Select(store => store.AddressId).ToListAsync();
            var addressIdsAsString = string.Join(",", addressIds.Select(id => id.ToString()));
            return addressIdsAsString;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

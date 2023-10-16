using Microsoft.EntityFrameworkCore;
using System.Text.Json;
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
            Status = OrderStatus.Pending,
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

            return new OrderAmount
            {
                OrderId = orderId,
                Amount = total,
                StoreId = order.StoreId
            };
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
                status = await SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    private async Task<bool> SaveChanges()
    {
        int rowsAffected = await _context.SaveChangesAsync();
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
            string requestUrl = "http://localhost:5226/api/stores/nearby/" + customerAddressId;

            HttpClient httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                int addressId = JsonSerializer.Deserialize<int>(apiResponse);
                return addressId;
            }
            return default;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> UpdateOrderStatus(OrderUpdateModel orderUpdate)
    {
        try
        {
            Order? order = await _context.Orders.FindAsync(orderUpdate.OrderId);
            if (order is not null)
            {
                switch (orderUpdate.Status)
                {
                    case OrderStatus.Approved:
                        return await OnOrderApproved(order);
                    case OrderStatus.Cancelled:
                        return await OnOrderCancelled(order);
                    case OrderStatus.ReadyToDispatch:
                        return await OnOrderReadyToDispatch(order);
                    case OrderStatus.Picked:
                        return await OnOrderPicked(order);
                    case OrderStatus.InProgress:
                        return await OnOrderInProgress(order);
                    case OrderStatus.Delivered:
                        return await OnOrderDelivered(order);
                    default:
                        throw new Exception($"Invalid status {orderUpdate.Status}");
                }
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<bool> OnOrderReadyToDispatch(Order order)
    {
        try
        {  var shipperId = await GetNearestShipperId(order.StoreId);
            Console.WriteLine("--->>>"+shipperId);
            ShipperOrder shipperOrder = new ShipperOrder()
            {
                OrderId = order.Id,
                ShipperId = shipperId != default ? shipperId : 1
            };
            await _context.ShipperOrders.AddAsync(shipperOrder);
            order.Status = OrderStatus.ReadyToDispatch;
            return await SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<bool> OnOrderPicked(Order order)
    {
        try
        {
            order.Status = OrderStatus.Picked;
            return await SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<bool> OnOrderInProgress(Order order)
    {
        try
        {
            order.Status = OrderStatus.InProgress;
            return await SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<bool> OnOrderDelivered(Order order)
    {
        try
        {
            order.Status = OrderStatus.Delivered;
            order.ShippedDate= DateTime.Now; 
            return await SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<bool> OnOrderCancelled(Order order)
    {
        try
        {
            var orderDetails = await _context.OrderDetails
                .Where(od => od.OrderId == order.Id)
                .ToListAsync();
            foreach (var item in orderDetails)
            {
                ProductDetail? productDetails = await _context.ProductDetails.FindAsync(
                    item.ProductDetailsId
                );
                if (productDetails != null)
                {
                    productDetails.StockAvailable = productDetails.StockAvailable + item.Quantity;
                    _context.Entry(productDetails).State = EntityState.Modified;
                }
            }
            order.Status = OrderStatus.Cancelled;
            return await SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<bool> OnOrderApproved(Order order)
    {
        try
        {
            order.Status = OrderStatus.Approved;
            return await SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<int> GetNearestShipperId(int storeId)
    {
        try
        {
            string requestUrl = "http://localhost:5298/api/shippers/nearby/" + storeId;

            HttpClient httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                int shipperId = JsonSerializer.Deserialize<int>(apiResponse);
                return shipperId;
            }
            return default;
        }
        catch (Exception)
        {
            throw;
        }
    }


}

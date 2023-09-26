using OrderProcessing.Repositories.Interfaces;
using OrderProcessing.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using OrderProcessing.Models;
using OrderProcessing.Entities;

namespace OrderProcessing.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }

    public async Task<OrderAmount> CreateOrder(OrderAddModel orderAddModel)
    {
        try
        {
            Order order1 = new Order()
            {
                Id = 0,
                CustomerId = orderAddModel.CustomerId,
                AddressId = orderAddModel.AddressId,
                Status = "initiated",
                Total = 0
            };
            await _context.AddAsync(order1);
            await _context.SaveChangesAsync();

            int orderId = order1.Id;
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
                }
            await _context.SaveChangesAsync();

            var total = await (
                from od in _context.OrderDetails
                where od.OrderId == orderId
                join pd in _context.ProductDetails on od.ProductDetailsId equals pd.Id
                select pd.UnitPrice * od.Quantity
            ).SumAsync();

            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Total = total;
                await _context.SaveChangesAsync();
            }

            return new OrderAmount { OrderId = orderId, Amount = total };
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
}

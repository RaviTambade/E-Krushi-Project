using OrderProcessing.Models;

namespace OrderProcessing.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<OrderAmount> CreateOrder(OrderAddModel order);
    Task<bool> RemoveOrder(int orderId);
}

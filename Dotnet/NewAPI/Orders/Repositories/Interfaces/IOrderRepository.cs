using Transflower.EKrushi.Orders.Models;

namespace Transflower.EKrushi.Orders.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<OrderAmount> CreateOrder(OrderAddModel order);
    Task<bool> RemoveOrder(int orderId);
    Task<List<OrderDetailModel>> GetOrderDetails(int orderId);

    Task<List<CustomerOrder>> GetCustomerOrderDetails(int customerId);
    Task<double> GetOrderAmount(int orderId);
}

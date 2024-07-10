using Transflower.EKrushi.Orders.Models;

namespace Transflower.EKrushi.Orders.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<OrderAmount> CreateOrder(OrderAddModel order);
    Task<bool> RemoveOrder(int orderId);
    Task<List<OrderDetailModel>> GetOrderDetails(int orderId);
    Task<List<CustomerOrder>> GetCustomerOrders(int customerId, string orderStatus);
    Task<double> GetOrderAmount(int orderId);
    Task<int> GetAddressIdOfOrder(int orderId);
    
     Task<bool> UpdateOrderStatus(OrderUpdateModel order);
   
}

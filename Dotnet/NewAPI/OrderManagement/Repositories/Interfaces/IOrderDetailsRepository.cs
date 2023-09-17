using Transflower.EKrushi.OrderManagement.Models;

namespace Transflower.EKrushi.OrderManagement.Repositories.Interfaces;

public interface IOrderDetailsRepository{

    Task<List<OrderDetails>> GetAllOrderDetails();

    Task<OrderDetails> GetOrderDetail(int id);
    
    Task<bool> Insert(OrderDetails orderDetail);

    Task<bool> Update(OrderDetails orderDetail);

    Task<bool> Delete(int id);

    Task<List<OrderHistory>> GetDetails(int orderId);

    
    
}
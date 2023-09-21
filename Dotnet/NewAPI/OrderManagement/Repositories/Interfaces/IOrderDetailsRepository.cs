using Transflower.EKrushi.OrderManagement.Models;

namespace Transflower.EKrushi.OrderManagement.Repositories.Interfaces;

public interface IOrderDetailsRepository{

   
    Task<OrderDetails> GetOrderDetail(int id);
    
    Task<bool> Delete(int id);

    Task<List<OrderDetails>> GetDetails(int orderId);

    
    
}
using Transflower.EKrushi.OrderManagement.Models;

namespace Transflower.EKrushi.OrderManagement.Repositories.Interfaces;

public interface IOrderDetailsRepository{

    

    Task<List<OrderDetails>> GetDetails(int orderId);

    
    
}
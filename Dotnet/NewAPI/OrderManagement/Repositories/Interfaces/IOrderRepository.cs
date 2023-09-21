using Transflower.EKrushi.OrderManagement.Models;

namespace Transflower.EKrushi.OrderManagement.Repositories.Interfaces;

public interface IOrderRepository{

    
    
    Task<List<CustomerOrder>> GetOrderDetails(int customerid);
    CustomerOrder GetOrderDetailsByOrderId(int orderid);
}
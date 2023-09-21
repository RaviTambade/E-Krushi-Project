using Transflower.EKrushi.OrderManagement.Models;

namespace Transflower.EKrushi.OrderManagement.Repositories.Interfaces;

public interface IOrderRepository{

    Task<List<Order>> Orders();
    Task<Order> GetOrder(int id);
    Task<List<Order>> OrderByCustId(int id);
    Task<bool> Insert(Order order);
    Task<bool> Update(Order order);
    Task<bool> Delete(int id);
    Task<List<Order>> Delivered();
    Task<List<Order>> Cancelled();
    Task<int> GetCountByDate(DateTime date);
    Task<int>  TotalCount();
    // Task<List<OrderHistory>> GetOrderHistory(int custId);
    Task<List<CustomerOrder>> GetOrderDetails(int customerid);
    Task<List<Order>> FilterDate(DateTime fromDate,DateTime toDate);
   


}
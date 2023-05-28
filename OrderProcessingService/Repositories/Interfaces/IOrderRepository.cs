using OrderProcessingService.Models;

namespace OrderProcessingService.Repositories.Interfaces;

public interface IOrderRepository{

    Task<List<Order>> Orders();
    Task<Order> GetOrder(int id);
    Task<Order> OrderByCustId(int id);
    Task<bool> Insert(Order order);
    Task<bool> Update(Order order);
    Task<bool> Delete(int id);
    Task<List<Order>> Delivered();
    Task<List<Order>> Cancelled();
    Task<int> GetCountByDate(DateTime date);
    Task<int>  TotalCount();
    
}
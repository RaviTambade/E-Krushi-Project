using OrderProcessingService.Models;

namespace OrderProcessingService.Repositories.Interfaces;

public interface IOrderRepository{

    List<Order> Orders();

    Order GetOrder(int id);

    Order OrderByCustId(int id);
    bool Insert(Order order);

    bool Update(Order order);

    bool Delete(int id);

    List<Order> Delivered();

    List<Order> Cancelled();

    int  GetCountByDate(DateTime date);

    int  TotalCount();
    
}
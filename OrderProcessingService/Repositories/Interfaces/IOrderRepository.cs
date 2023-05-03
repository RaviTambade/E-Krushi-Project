using OrderProcessingService.Models;

namespace OrderProcessingService.Repositories.Interfaces;

public interface IOrderRepository{

    List<Order> GetAllOrders();

    Order GetOrder(int id);

    Order GetOrderByCustId(int id);
    bool InsertOrder(Order order);

    bool UpdateOrder(Order order);

    bool DeleteOrder(int id);

    List<Order> GetAllDelivered();

    List<Order> GetAllCancelled();
    
}
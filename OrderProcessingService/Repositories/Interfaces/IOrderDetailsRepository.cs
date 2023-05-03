using OrderProcessingService.Models;

namespace OrderProcessingService.Repositories.Interfaces;

public interface IOrderDetailsRepository{

    List<OrderDetails> GetAllOrderDetails();

    OrderDetails GetOrderDetail(int id);
    
    bool InsertOrderDetail(OrderDetails order);

    bool UpdateOrderDetail(OrderDetails order);

    bool DeleteOrderDetail(int id);

    
    
}
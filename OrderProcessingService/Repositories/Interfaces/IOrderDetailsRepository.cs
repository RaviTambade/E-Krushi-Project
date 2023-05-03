using OrderProcessingService.Models;

namespace OrderProcessingService.Repositories.Interfaces;

public interface IOrderDetailsRepository{

    List<OrderDetails> GetAllOrderDetails();

    OrderDetails GetOrderDetail(int id);
    
    bool InsertOrderDetail(OrderDetails orderDetail);

    bool UpdateOrderDetail(OrderDetails orderDetail);

    bool DeleteOrderDetail(int id);

    
    
}
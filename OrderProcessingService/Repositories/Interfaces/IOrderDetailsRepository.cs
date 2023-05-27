using OrderProcessingService.Models;

namespace OrderProcessingService.Repositories.Interfaces;

public interface IOrderDetailsRepository{

    List<OrderDetails> OrderDetails();

    OrderDetails OrderDetail(int id);
    
    bool Insert(OrderDetails orderDetail);

    bool Update(OrderDetails orderDetail);

    bool Delete(int id);

    
    
}
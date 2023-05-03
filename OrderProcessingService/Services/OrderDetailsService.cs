using System.Collections;
using System.Threading.Tasks;
using OrderProcessingService.Models;
using OrderProcessingService.Repositories.Interfaces;

namespace OrderProcessingService.Services;
public class OrderDetailsService : IOrderDetailsService{
    private readonly IOrderDetailsRepository _repo;
    public OrderDetailsService(IOrderDetailsRepository repo){
        this._repo=repo;
    }

  
    public List<OrderDetails> GetAllOrderDetails() => _repo.GetAllOrderDetails();

    public OrderDetails GetOrderDetail(int id) => _repo.GetOrderDetail(id);

    public bool InsertOrderDetail(OrderDetails orderDetail)=> _repo.InsertOrderDetail(orderDetail);

    public bool UpdateOrderDetail(OrderDetails orderDetail)=> _repo.UpdateOrderDetail(orderDetail);

    public bool DeleteOrderDetail(int id)=>  _repo.DeleteOrderDetail(id);


}
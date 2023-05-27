using System.Collections;
using System.Threading.Tasks;
using OrderProcessingService.Models;
using OrderProcessingService.Repositories.Interfaces;
using OrderProcessingService.Services.Interfaces;

namespace OrderProcessingService.Services;

public class OrderDetailsService : IOrderDetailsService{
    private readonly IOrderDetailsRepository _repo;
    public OrderDetailsService(IOrderDetailsRepository repo){
        this._repo=repo;
    }

  
    public List<OrderDetails> OrderDetails() => _repo.OrderDetails();

    public OrderDetails OrderDetail(int id) => _repo.OrderDetail(id);

    public bool Insert(OrderDetails orderDetail)=> _repo.Insert(orderDetail);

    public bool Update(OrderDetails orderDetail)=> _repo.Update(orderDetail);

    public bool Delete(int id)=>  _repo.Delete(id);


}
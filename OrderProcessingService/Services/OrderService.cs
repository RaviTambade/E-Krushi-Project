using System.Collections;
using System.Threading.Tasks;
using OrderProcessingService.Models;
using OrderProcessingService.Repositories.Interfaces;
using OrderProcessingService.Services.Interfaces;

namespace OrderProcessingService.Services;
public class OrderService : IOrderService{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo){
        this._repo=repo;
    }

  
    public List<Order> Orders() => _repo.Orders();

    public Order GetOrder(int id) => _repo.GetOrder(id);

    public Order OrderByCustId(int id) => _repo.OrderByCustId(id);

    public bool Insert(Order order)=> _repo.Insert(order);

    public bool Update(Order order)=> _repo.Update(order);

    public bool Delete(int id)=>  _repo.Delete(id);

    public List<Order> Cancelled() => _repo.Cancelled();

    public List<Order> Delivered() => _repo.Delivered();

    public int GetCountByDate(DateTime date) => _repo.GetCountByDate(date);

    public int TotalCount() => _repo.TotalCount();
}
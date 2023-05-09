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

  
    public List<Order> GetAllOrders() => _repo.GetAllOrders();

    public Order GetOrder(int id) => _repo.GetOrder(id);

    public Order GetOrderByCustId(int id) => _repo.GetOrderByCustId(id);

    public bool InsertOrder(Order order)=> _repo.InsertOrder(order);

    public bool UpdateOrder(Order order)=> _repo.UpdateOrder(order);

    public bool DeleteOrder(int id)=>  _repo.DeleteOrder(id);

    public List<Order> GetAllCancelled() => _repo.GetAllCancelled();

    public List<Order> GetAllDelivered() => _repo.GetAllDelivered();

    public int GetCountByDate(DateTime date) => _repo.GetCountByDate(date);


}
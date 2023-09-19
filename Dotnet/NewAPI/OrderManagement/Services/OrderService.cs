using System.Collections;
using System.Threading.Tasks;
using Transflower.EKrushi.OrderManagement.Models;
using Transflower.EKrushi.OrderManagement.Repositories.Interfaces;
using Transflower.EKrushi.OrderManagement.Services.Interfaces;

namespace Transflower.EKrushi.OrderManagement.Services;
public class OrderService : IOrderService{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo){
        this._repo=repo;
    }

  
    public async Task<List<Order>> Orders() => await _repo.Orders();

    public async Task<Order> GetOrder(int id) => await _repo.GetOrder(id);

    public async Task<List<Order>> OrderByCustId(int id) =>await _repo.OrderByCustId(id);

    public async Task<bool> Insert(Order order)=> await _repo.Insert(order);

    public async Task<bool> Update(Order order)=> await _repo.Update(order);

    public async Task<bool> Delete(int id)=> await _repo.Delete(id);

    public async Task<List<Order>> Cancelled() => await _repo.Cancelled();

    public async Task<List<Order>> Delivered() => await _repo.Delivered();

    public async Task<int> GetCountByDate(DateTime date) => await _repo.GetCountByDate(date);

    public async Task<int> TotalCount() => await _repo.TotalCount();

    public async Task<List<OrderHistory>> GetOrderHistory(int custId) => await _repo.GetOrderHistory(custId);

    public async Task<List<CustomerOrder>> GetOrderDetails(int customerid) => await _repo.GetOrderDetails(customerid);

    public async Task<List<Order>> FilterDate(DateTime fromDate,DateTime toDate) => await _repo.FilterDate(fromDate,toDate);

    
}
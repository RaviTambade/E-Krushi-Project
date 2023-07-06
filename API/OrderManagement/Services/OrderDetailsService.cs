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

  
    public async Task<List<OrderDetails>> GetAllOrderDetails() => await _repo.GetAllOrderDetails();

    public async Task<OrderDetails> GetOrderDetail(int id) => await _repo.GetOrderDetail(id);

    public async Task<bool> Insert(OrderDetails orderDetail)=> await _repo.Insert(orderDetail);

    public async Task<bool> Update(OrderDetails orderDetail)=> await _repo.Update(orderDetail);

    public async Task<bool> Delete(int id)=> await _repo.Delete(id);

     public async Task<List<OrderHistory>> GetDetails(int orderId) => await _repo.GetDetails(orderId);


}
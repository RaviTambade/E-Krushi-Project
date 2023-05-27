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

  
    public async Task<List<OrderDetails>> OrderDetails() => await _repo.OrderDetails();

    public async Task<OrderDetails> OrderDetail(int id) => await _repo.OrderDetail(id);

    public async Task<bool> Insert(OrderDetails orderDetail)=> await _repo.Insert(orderDetail);

    public async Task<bool> Update(OrderDetails orderDetail)=> await _repo.Update(orderDetail);

    public async Task<bool> Delete(int id)=> await _repo.Delete(id);


}
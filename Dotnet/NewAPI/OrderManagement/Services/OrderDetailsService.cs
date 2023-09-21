using System.Collections;
using System.Threading.Tasks;
using Transflower.EKrushi.OrderManagement.Models;
using Transflower.EKrushi.OrderManagement.Repositories.Interfaces;
using Transflower.EKrushi.OrderManagement.Services.Interfaces;

namespace Transflower.EKrushi.OrderManagement.Services;

public class OrderDetailsService : IOrderDetailsService{
    private readonly IOrderDetailsRepository _repo;
    public OrderDetailsService(IOrderDetailsRepository repo){
        this._repo=repo;
    }

  
    
    public async Task<OrderDetails> GetOrderDetail(int id) => await _repo.GetOrderDetail(id);

   
    public async Task<bool> Delete(int id)=> await _repo.Delete(id);

     public async Task<List<OrderDetails>> GetDetails(int orderId) => await _repo.GetDetails(orderId);


}
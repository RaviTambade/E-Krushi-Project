using System.Collections;
using System.Threading.Tasks;
using Transflower.EKrushi.OrderManagement.Models;
using Transflower.EKrushi.OrderManagement.Repositories.Interfaces;
using Transflower.EKrushi.OrderManagement.Services.Interfaces;

namespace Transflower.EKrushi.OrderManagement.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo)
    {
        this._repo = repo;
    }






    public async Task<List<CustomerOrder>> GetOrderDetails(int customerid) => await _repo.GetOrderDetails(customerid);


}
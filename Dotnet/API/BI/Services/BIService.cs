using System.Collections;
using System.Threading.Tasks;
using Transflower.EKrushi.BIService.Models;
using Transflower.EKrushi.BIService.Repositories.Interfaces;
using Transflower.EKrushi.BIService.Services.Interfaces;

namespace Transflower.EKrushi.BIService.Services;
public class BIServices : IBIService{
    private readonly IBIRepository _repo;
    public BIServices(IBIRepository repo){
        this._repo=repo;
    }

    public async Task<List<OrderChart>> GetCountByMonth(int year) => await _repo.GetCountByMonth(year);

    public async Task<List<OrderChart>> OrderStatus(int year) => await _repo.OrderStatus(year);

    public async Task<List<ProductSale>> GetProductReport(int year) => await _repo.GetProductReport(year);

    public async Task<List<CustomerReport>> GetCustomerReport(int custId) => await _repo.GetCustomerReport(custId);

    public async Task<List<SMEReport>> GetSMEReport(int year) => await _repo.GetSMEReport(year);

    public async Task<List<OrderChart>> GetTotalRevenue(int year) => await _repo.GetTotalRevenue(year);
  
    public async Task<List<OrderChart>> GetWeeklyOrders(int year) => await _repo.GetWeeklyOrders(year);

    public async Task<List<OrderChart>> GetYearlyOrders() => await _repo.GetYearlyOrders();

    public async Task<List<OrderChart>> GetYearlySMEPerformance() => await _repo.GetYearlySMEPerformance();


}
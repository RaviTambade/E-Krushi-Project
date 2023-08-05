using System.Collections;
using System.Threading.Tasks;
using BIService.Models;
using BIService.Repositories.Interfaces;
using BIService.Services.Interfaces;

namespace BIService.Services;
public class BIServices : IBIService{
    private readonly IBIRepository _repo;
    public BIServices(IBIRepository repo){
        this._repo=repo;
    }

     public async Task<List<OrderChart>> GetCountByMonth(int year) => await _repo.GetCountByMonth(year);

     public async Task<List<OrderChart>> OrderStatus(int year) => await _repo.OrderStatus(year);
}
using System.Collections;
using System.Threading.Tasks;
using Stores.Models;

using Transflower.EKrushi.BIService.Repositories.Interfaces;
using Transflower.EKrushi.BIService.Services.Interfaces;

namespace Transflower.EKrushi.BIService.Services;
public class BIServices : IBIService{
    private readonly IBIRepository _repo;
    public BIServices(IBIRepository repo){
        this._repo=repo;
    }

    public OrderSp OrdersStoredProcedure(DateTime todaysDate,int storeId){
        return _repo.OrdersStoredProcedure(todaysDate,storeId);
     }
     public List<TopProducts> GetTopProducts(DateTime todaysDate,string mode){
        return _repo.GetTopProducts(todaysDate,mode);
     }
}
using Stores.Models;


namespace Transflower.EKrushi.BIService.Repositories.Interfaces;

public interface IBIRepository{
   OrderSp OrdersStoredProcedure(DateTime todaysDate,int storeId);
   List<TopProducts> GetTopProducts(DateTime todaysDate);
}
using Transflower.EKrushi.BIService.Models;

namespace Transflower.EKrushi.BIService.Repositories.Interfaces;

public interface IBIRepository
{
    Task<OrderCount> OrdersCountByStore(DateTime todaysDate, int storeId);
    Task<List<TopProducts>> GetTopFiveSellingProducts(DateTime todaysDate, string mode,int storeId);
}

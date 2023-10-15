using Transflower.EKrushi.BIService.Models;

namespace Transflower.EKrushi.BIService.Repositories.Interfaces;

public interface IBIRepository
{
    Task<OrderCount> OrdersCountByStore(DateTime todaysDate, int storeId);
    Task<List<TopProducts>> GetTopFiveSellingProducts(DateTime todaysDate, string mode,int storeId);

    Task<List<MonthOrders>> GetMonthOrders(int year, int storeId);

    Task<List<CategorywiseProduct>> GetCategorywiseProductsCount(DateTime todaysDate, string mode,int storeId);

    Task<List<DeliveredOrders>> GetDeliveredOrdersbyMonth(int year,int shipperId);

    Task<List<NotAnsweredQuestions>> GetNotAnsweredQuestions(int userId);
}

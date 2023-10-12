using Transflower.EKrushi.BIService.Models;
using Transflower.EKrushi.BIService.Repositories.Interfaces;
using Transflower.EKrushi.BIService.Services.Interfaces;

namespace Transflower.EKrushi.BIService.Services;

public class BIServices : IBIService
{
    private readonly IBIRepository _repository;

    public BIServices(IBIRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TopProducts>> GetTopFiveSellingProducts(
        DateTime todaysDate,
        string mode,
        int storeId
    )
    {
        if (isModeInvalid(mode))
        {
            throw new Exception($"Argument Mode={mode} is Invalid");
        }
        return await _repository.GetTopFiveSellingProducts(todaysDate, mode, storeId);
    }

    public async Task<OrderCount> OrdersCountByStore(DateTime todaysDate, int storeId)
    {
        return await _repository.OrdersCountByStore(todaysDate, storeId);
    }


 public async Task<List<MonthOrders>> GetMonthOrders(int year, int storeId)=>await _repository.GetMonthOrders(year, storeId);
   
    bool isModeInvalid(string mode)
    {
        return mode != OrderMode.Month
            && mode != OrderMode.Today
            && mode != OrderMode.Yesterday
            && mode != OrderMode.Week;
    }
}

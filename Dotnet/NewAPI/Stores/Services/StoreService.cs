using Stores.Services.Interfaces;
using Stores.Repositories.Interfaces;
using Stores.Models;

namespace Stores.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _repository;

    public StoreService(IStoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId , string orderStatus)
    {
        return await _repository.GetAllStoreOrders(storeId,orderStatus);
    }

    public async Task<int> GetNearestStoreId(int customerAddressId)
    {
        return await _repository.GetNearestStoreId(customerAddressId);
    }

    public OrderSp OrdersStoredProcedure(DateTime todaysDate, int storeId)
    {
        return _repository.OrdersStoredProcedure(todaysDate, storeId);
    }

    public async Task<int> GetStoreUserId(int storeId)
    {
        return await _repository.GetStoreUserId(storeId);
    }

    public async Task<int> GetStoreIdByUserId(int userId)
    {
        return await _repository.GetStoreIdByUserId(userId);
    }
}

using Transflower.EKrushi.Stores.Services.Interfaces;
using Transflower.EKrushi.Stores.Repositories.Interfaces;
using Transflower.EKrushi.Stores.Models;

namespace Transflower.EKrushi.Stores.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _repository;

    public StoreService(IStoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StoreOrder>> GetStoreOrders(int storeId , string orderStatus)
    {
        return await _repository.GetStoreOrders(storeId,orderStatus);
    }

    public async Task<int> GetNearestStoreId(int customerAddressId)
    {
        return await _repository.GetNearestStoreId(customerAddressId);
    }

    public async Task<int> GetStoreUserId(int storeId)
    {
        return await _repository.GetStoreUserId(storeId);
    }

    public async Task<int> GetStoreIdByUserId(int userId)
    {
        return await _repository.GetStoreIdByUserId(userId);
    }

    public async Task<OrderStatusCount> GetStoreOrdersCount(int storeId)
    {
        return await _repository.GetStoreOrdersCount(storeId);
    }

    public async Task<StoreName> GetStoreNameByStoreId(int storeId)
    {
        return await _repository.GetStoreNameByStoreId(storeId);
    }
}

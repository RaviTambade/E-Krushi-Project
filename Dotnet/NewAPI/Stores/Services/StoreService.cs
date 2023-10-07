
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

    public async Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId)
    {
       return await  _repository.GetAllStoreOrders(storeId);
    }

    public async  Task<int> GetNearestStoreId(int customerAddressId)
    {
       return await  _repository.GetNearestStoreId(customerAddressId);
        
    }

   
    public async Task<int> GetStoreUserId(int storeId)
    {
       return await  _repository.GetStoreUserId(storeId);
    }
}
using Stores.Models;

namespace Stores.Repositories.Interfaces;

public interface IStoreRepository
{
    Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId, string orderStatus);
    Task<int> GetNearestStoreId(int customerAddressId);
    Task<int> GetStoreUserId(int storeId);
    Task<int> GetStoreIdByUserId(int userId);
    OrderSp OrdersStoredProcedure(DateTime todaysDate,int storeId);
}

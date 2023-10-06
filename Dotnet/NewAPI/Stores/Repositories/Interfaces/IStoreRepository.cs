using Stores.Models;

namespace Stores.Repositories.Interfaces;

public interface IStoreRepository
{
Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId);
Task<int> GetNearestStoreId(int customerAddressId);

 public OrderSp OrdersStoredProcedure(DateTime todaysDate);

Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId);
Task<int> GetNearestStoreId(int customerAddressId);
Task<int> GetStoreUserId(int storeId);
}

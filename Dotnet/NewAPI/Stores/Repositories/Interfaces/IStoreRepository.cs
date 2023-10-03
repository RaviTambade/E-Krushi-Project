
using Stores.Models;

namespace Stores.Repositories.Interfaces;
public interface IStoreRepository
{
Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId);
Task<int> GetNearestStoreId(int customerAddressId);
}
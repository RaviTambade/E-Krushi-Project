using Transflower.EKrushi.Stores.Models;

namespace Transflower.EKrushi.Stores.Repositories.Interfaces;

public interface IStoreRepository
{
    Task<IEnumerable<StoreOrder>> GetStoreOrders(int storeId, string orderStatus);
    Task<OrderStatusCount> GetStoreOrdersCount(int storeId);

    Task<int> GetNearestStoreId(int customerAddressId);
    Task<int> GetStoreUserId(int storeId);
    Task<int> GetStoreIdByUserId(int userId);
    Task<StoreName> GetStoreNameByStoreId(int storeId);
}


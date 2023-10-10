using TransFlower.EKrushi.Shippers.Models;

namespace TransFlower.EKrushi.Shippers.Repositories.Interfaces;

public interface IShipperRepository
{
    Task<int> GetNearestShipperId(int storeId);
    Task<int> GetShipperIdByUserId(int userId);
    Task<OrderStatusCount> GetShipperOrdersCount(int shipperId);

    Task<IEnumerable<ShipperOrder>> GetShipperOrdersByStatus(int shipperId, string status);
}

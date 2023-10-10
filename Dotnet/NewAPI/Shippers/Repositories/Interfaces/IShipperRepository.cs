
using TransFlower.EKrushi.Shippers.Models;

namespace TransFlower.EKrushi.Shippers.Repositories.Interfaces;
public interface IShipperRepository
{
    Task<int> GetNearestShipperId(int storeId);
    Task<IEnumerable<ShipperOrder>> GetShipperOrdersByStatus(int shipperId,string status);

}

using Shippers.Models;

namespace Shippers.Repositories.Interfaces;
public interface IShipperRepository
{
    Task<int> GetNearestShipperId(int storeId);

}
using TransFlower.EKrushi.Shippers.Services.Interfaces;
using TransFlower.EKrushi.Shippers.Repositories.Interfaces;
using TransFlower.EKrushi.Shippers.Models;

namespace TransFlower.EKrushi.Shippers.Services;

public class ShipperService : IShipperService
{
    private readonly IShipperRepository _repository;

    public ShipperService(IShipperRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> GetNearestShipperId(int storeId)
    {
        return await _repository.GetNearestShipperId(storeId);
    }

    public async Task<IEnumerable<ShipperOrder>> GetShipperOrdersByStatus(int shipperId, string status)
    {
        return await _repository.GetShipperOrdersByStatus(shipperId, status);
    }
}


using Shippers.Services.Interfaces;
using Shippers.Repositories.Interfaces;
using Shippers.Models;

namespace Shippers.Services;
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
}
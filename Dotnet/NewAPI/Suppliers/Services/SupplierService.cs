using Transflower.EKrushi.Suppliers.Repositories.Interfaces;
using Transflower.EKrushi.Suppliers.Services.Interfaces;

namespace Transflower.EKrushi.Suppliers.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierService(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> GetCorporateIdOfSupplier(int supplierId)
    {
        return await _repository.GetCorporateIdOfSupplier(supplierId);
    }

    public async Task<int> GetSupplierId(int userId)
    {
        return await _repository.GetSupplierId(userId);
    }
}

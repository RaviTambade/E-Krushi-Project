


namespace Transflower.EKrushi.Suppliers.Repositories.Interfaces;
public interface ISupplierRepository
{
    Task<int> GetCorporateIdOfSupplier(int supplierId);
    Task<int> GetSupplierId(int userId);


}
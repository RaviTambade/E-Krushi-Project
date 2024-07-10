using Transflower.EKrushi.Catalog.Models;

namespace Transflower.EKrushi.Catalog.Repositories.Interfaces
{
    public interface IProductRepository{

        
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProduct(int id);
    Task<bool> Insert(Product product);
    Task<bool> Update(Product product);
    Task<bool> DeleteProduct(int id);
    Task<Product> GetProductDetails(string title);
    Task<List<Product>> GetProductsDetails(string categoryName);
    Task<bool> UpdateStockAvailable(Procedure updateStock);
    
    }
}
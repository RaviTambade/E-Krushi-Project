using ProService.Models;
using ProService.Models;

namespace ProService.Repositories.Interfaces
{
    public interface IProductRepository{

        
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProduct(int id);
    Task<bool> Insert(Product product);
    Task<bool> Update(Product product);
     Task<bool> DeleteProduct(int id);

     //Task<List<Products>> GetProductsDetails(string categoryName);
    }
}
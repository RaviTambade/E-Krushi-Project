using CatlogService.Models;

namespace CatlogService.Repositories.Interfaces
{
    public interface ICatalogRepository{

        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(int id);
        Task<bool> Insert(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(int id);

    // Task<List<Product>> GetAllProducts();
    // Task<Product> GetProduct(int id);
    // Task<bool> Insert(Product product);
    // Task<bool> Update(Product product);
    // Task<bool> Delete(int id);
    // Task<List<Products>> CategoryName(string categoryName);
    }
}
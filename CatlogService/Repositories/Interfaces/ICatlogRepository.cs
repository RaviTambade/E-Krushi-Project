using CatlogService.Models;

namespace CatlogService.Repositories.Interfaces
{
    public interface ICatalogRepository{
    Task<List<Products>> GetProductsDetails(string categoryName);
    }
}
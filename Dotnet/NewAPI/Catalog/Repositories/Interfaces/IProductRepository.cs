using Transflower.EKrushi.Catalog.Models;

namespace Transflower.EKrushi.Catalog.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<double> GetProductPricebySize(int productId, string size);
    Task<List<Product>> GetProductsByCategory(int categoryId);
    Task<List<Product>> GetSearchedProducts(string productName);
    Task<List<Product>> GetSimilarProducts(int productId);

    Task<ProductDescription?> GetProductdetails(int productId);
    Task<List<string>> GetProductNameSuggestions(string searchString);
}

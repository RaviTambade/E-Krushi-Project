using Catalog.Models;

namespace Catalog.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<double> GetProductPricebySize(int productId, string size);
    Task<List<Product>> GetProductsByCategory(int categoryId);
    Task<List<Product>> GetSearchedProducts(string productName);
    Task<List<Product>> GetSimilarProducts(int productId);

    Task<ProductDetail?> GetProductdetails(int productId);
}

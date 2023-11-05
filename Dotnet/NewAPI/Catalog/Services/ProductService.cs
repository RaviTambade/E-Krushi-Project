using Transflower.EKrushi.Catalog.Services.Interfaces;
using Transflower.EKrushi.Catalog.Repositories.Interfaces;
using Transflower.EKrushi.Catalog.Models;

namespace Transflower.EKrushi.Catalog.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _repository.GetProducts();
    }

    public async Task<double> GetProductPricebySize(int productId, string size)
    {
        return await _repository.GetProductPricebySize(productId, size);
    }

    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        return await _repository.GetProductsByCategory(categoryId);
    }

    public async Task<List<Product>> GetSearchedProducts(string productName)
    {
        return await _repository.GetSearchedProducts(productName);
    }

    public async Task<ProductDescription?> GetProductdetails(int productId)
    {
        return await _repository.GetProductdetails(productId);
    }

    public async Task<List<Product>> GetSimilarProducts(int productId)
    {
        return await _repository.GetSimilarProducts(productId);
    }

    public async Task<List<string>> GetProductNameSuggestions(string searchString)
    {
        return await _repository.GetProductNameSuggestions(searchString);
    }

    public async Task<List<Product>> GetProductsBySupplier(int supplierId)
    {
        return await _repository.GetProductsBySupplier(supplierId);
    }
}

using Catalog.Services.Interfaces;
using Catalog.Repositories.Interfaces;
using Catalog.Models;

namespace Catalog.Services;

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

    public async Task<double> GetProductPricebySize(int productId,string size)
    {
        return await _repository.GetProductPricebySize(productId,size);
    }

    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        return await _repository.GetProductsByCategory(categoryId);
    }
}

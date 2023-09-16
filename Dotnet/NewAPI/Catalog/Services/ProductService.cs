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

    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        return await _repository.GetProductsByCategory(categoryId);
    } 
}

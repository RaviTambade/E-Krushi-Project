
using Catalog.Models;

namespace Catalog.Repositories.Interfaces;
public interface IProductRepository
{
    Task<List<Product>> GetProductsByCategory(int categoryId);
    
}
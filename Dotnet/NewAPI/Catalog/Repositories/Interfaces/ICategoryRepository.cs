
using Catalog.Models;

namespace Catalog.Repositories.Interfaces;
public interface ICategoryRepository
{
    Task<List<Category>> GetCategories();
    
}
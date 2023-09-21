
using Transflower.EKrushi.Catalog.Models;

namespace Transflower.EKrushi.Catalog.Repositories.Interfaces;
public interface ICategoryRepository
{
    Task<List<Category>> GetCategories();
    
}
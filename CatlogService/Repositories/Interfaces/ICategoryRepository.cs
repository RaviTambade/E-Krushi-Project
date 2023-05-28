using CatlogService.Models;

namespace CatlogService.Repositories.Interfaces
{
    public interface ICategoryRepository{

        Task<List<Category>> Categories();
        Task<Category> GetCategory(int id);
        Task<bool> Insert(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(int id);
    }
}
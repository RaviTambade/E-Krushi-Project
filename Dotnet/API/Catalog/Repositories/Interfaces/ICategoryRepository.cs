using Transflower.EKrushi.Catalog.Models;
namespace Transflower.EKrushi.Catalog.Repositories.Interfaces
{
    public interface ICategoryRepository{

        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<bool> Insert(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(int id);
    }
}

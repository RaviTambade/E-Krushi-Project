using CatlogService.Models;

namespace CatlogService.Repositories.Interfaces
{
    public interface ICategoryRepository{

        List<Category> Categories();
        Category GetCategory(int id);
        bool Insert(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }
}
using CatlogService.Models;

namespace CatlogService.Repositories.Interfaces
{
    public interface ICategoryRepository{

        List<Category> GetAllCategories();
        Category GetCategory(int id);
        bool InsertCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}
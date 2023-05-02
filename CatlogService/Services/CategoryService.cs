using CatlogService.Repositories.Interfaces;
using CatlogService.Service.Interfaces;
using CatlogService.Models;

namespace CatlogService.Repositories;

public class CategoryService : ICategoryService{

    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public List<Category> GetAllCategories() => _repo.GetAllCategories();
    public Category GetCategory(int id) => _repo.GetCategory(id);
    public bool InsertCategory(Category category) => _repo.InsertCategory(category);
    public bool UpdateCategory(Category category) => _repo.UpdateCategory(category);
    public bool DeleteCategory(int id) => _repo.DeleteCategory(id);

}
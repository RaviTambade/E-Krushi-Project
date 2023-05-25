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

    public List<Category> Categories() => _repo.Categories();
    public Category GetCategory(int id) => _repo.GetCategory(id);
    public bool Insert(Category category) => _repo.Insert(category);
    public bool Update(Category category) => _repo.Update(category);
    public bool Delete(int id) => _repo.Delete(id);

}
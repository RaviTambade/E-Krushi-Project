using CatalogService.Models;
using CatalogService.Repositories.Interfaces;
using CatalogService.Service.Interfaces;

namespace CatalogService.Repositories;

public class CategoryService : ICategoryService{

    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async  Task<List<Category>> GetAllCategories() =>await _repo.GetAllCategories();
    public async Task<Category> GetCategory(int id) =>await _repo.GetCategory(id);
    public async Task<bool> Insert(Category category) =>await _repo.Insert(category);
    public async Task<bool> Update(Category category) =>await _repo.Update(category);
    public async Task<bool> Delete(int id) => await _repo.Delete(id);



     
}
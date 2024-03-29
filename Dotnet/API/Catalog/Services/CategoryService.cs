using Transflower.EKrushi.Catalog.Models;
using Transflower.EKrushi.Catalog.Repositories.Interfaces;
using Transflower.EKrushi.Catalog.Service.Interfaces;

namespace Transflower.EKrushi.Catalog.Repositories;

public class CategoryService : ICategoryService{

    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async  Task<List<Category>> GetAll() =>await _repo.GetAll();
    public async Task<Category> GetById(int id) =>await _repo.GetById(id);
    public async Task<bool> Insert(Category category) =>await _repo.Insert(category);
    public async Task<bool> Update(Category category) =>await _repo.Update(category);
    public async Task<bool> Delete(int id) => await _repo.Delete(id);



     
}
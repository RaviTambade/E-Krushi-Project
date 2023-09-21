using Transflower.EKrushi.Catalog.Services.Interfaces;
using Transflower.EKrushi.Catalog.Repositories.Interfaces;
using Transflower.EKrushi.Catalog.Models;

namespace Transflower.EKrushi.Catalog.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Category>> GetCategories()
    {
        return await _repository.GetCategories();
    }
}

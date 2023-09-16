using Catalog.Services.Interfaces;
using Catalog.Repositories.Interfaces;
using Catalog.Models;

namespace Catalog.Services;

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

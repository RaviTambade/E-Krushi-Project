using CatlogService.Repositories.Interfaces;
using CatlogService.Service.Interfaces;
using CatlogService.Models;

namespace CatlogService.Repositories;

public class CatalogService : ICatalogService{

    private readonly ICatalogRepository _repo;

    public CatalogService(ICatalogRepository repo)
    {
        _repo = repo;
    }

    public async  Task<List<Category>> GetAllCategories() =>await _repo.GetAllCategories();
    public async Task<Category> GetCategory(int id) =>await _repo.GetCategory(id);
    public async Task<bool> Insert(Category category) =>await _repo.Insert(category);
    public async Task<bool> Update(Category category) =>await _repo.Update(category);
    public async Task<bool> Delete(int id) => await _repo.Delete(id);



//      public async Task<List<Product>> GetAllProducts() => await _repo.GetAllProducts();

//     public async Task<Product> GetProduct(int id) =>await _repo.GetProduct(id);

//     public async Task<bool> Insert(Product product) =>await _repo.Insert(product);

//     public async Task<bool> Update(Product product) =>await _repo.Update(product);
 
//     public async Task<bool> Delete(int id) => await _repo.Delete(id);

//     public async Task<List<Products>> CategoryName(string categoryName) =>await _repo.CategoryName(categoryName);
// 

}
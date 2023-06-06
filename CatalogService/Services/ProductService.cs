
using CatalogService.Models;
using CatalogService.Service.Interfaces;
using CatalogService.Repositories.Interfaces;


namespace CatalogService.Repositories;

public class ProductService : IProductService{

    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    


     public async Task<List<Product>> GetAllProducts() => await _repo.GetAllProducts();

    public async Task<Product> GetProduct(int id) =>await _repo.GetProduct(id);

    public async Task<bool> Insert(Product product) =>await _repo.Insert(product);

    public async Task<bool> Update(Product product) =>await _repo.Update(product);
 
    public async Task<bool> DeleteProduct(int id) => await _repo.DeleteProduct(id);

//   public async Task<List<Products>> GetProductsDetails(string categoryName) =>await _repo.GetProductsDetails(categoryName);

public async Task<Product> GetProductDetails(string title) =>await _repo.GetProductDetails(title);
    
}
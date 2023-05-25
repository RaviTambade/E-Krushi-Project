using CatlogService.Repositories.Interfaces;
using CatlogService.Service.Interfaces;
using CatlogService.Models;

namespace CatlogService.Repositories;

public class ProductService : IProductService{

    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public List<Product> Products() => _repo.Products();

    public Product GetProduct(int id) => _repo.GetProduct(id);

    public bool Insert(Product product) => _repo.Insert(product);

    public bool Update(Product product) => _repo.Update(product);
 
    public bool Delete(int id) => _repo.Delete(id);

    public List<ProductList> CategoryName(string categoryName) => _repo.CategoryName(categoryName);
}


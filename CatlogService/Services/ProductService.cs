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

    public List<Product> GetAllProducts() => _repo.GetAllProducts();

    public Product GetProduct(int id) => _repo.GetProduct(id);

    public bool InsertProduct(Product product) => _repo.InsertProduct(product);

    public bool UpdateProduct(Product product) => _repo.UpdateProduct(product);
 
    public bool DeleteProduct(int id) => _repo.DeleteProduct(id);

    public List<ProductList> GetByCategoryName(string categoryName) => _repo.GetByCategoryName(categoryName);
}


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

}


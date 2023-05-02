using CatlogService.Models;

namespace CatlogService.Repositories.Interfaces;

public interface IProductRepository{

    List<Product> GetAllProducts();
    Product GetProduct(int id);
}
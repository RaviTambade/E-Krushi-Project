using CatlogService.Models;

namespace CatlogService.Repositories.Interfaces;

public interface IProductRepository{

    List<Product> Products();
    Product GetProduct(int id);
    bool Insert(Product product);
    bool Update(Product product);
    bool Delete(int id);
    List<Products> CategoryName(string categoryName);
}
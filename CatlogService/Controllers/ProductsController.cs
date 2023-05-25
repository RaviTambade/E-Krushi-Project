using CatlogService.Models;
using CatlogService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatlogService.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }


    [HttpGet]
    [Route("products")]
    public IEnumerable<Product> Products()
    {
        List<Product> products = _service.Products();
        return products;
    }

    [HttpGet]
    [Route("products/{id}")]
    public Product GetProduct(int id)
    {
        Product product = _service.GetProduct(id);
        return product;
    }

    [HttpPost]
    [Route("Insert")]

    public bool Insert([FromBody] Product product)
    {
        bool result = _service.Insert(product);
        return result;
    }
    
    [HttpPut]
    [Route("Update/{id}")]

    public bool Update(int id, [FromBody] Product product)
    {
        Product oldProduct = _service.GetProduct(id);
        if(oldProduct.Id==0){
            return false;
        }
        product.Id = id;
        bool result = _service.Update(product);
        return result;
    }

    [HttpDelete]
    [Route("Delete/{id}")]

    public bool Delete(int id)
    {
        bool result = _service.Delete(id);
        return result;
    }

    [HttpGet]
    [Route("category/{categoryName}")]
    public List<ProductList> CategoryName(string categoryName)
    {
        List<ProductList> productList = _service.CategoryName(categoryName);
        return productList;
    }

}
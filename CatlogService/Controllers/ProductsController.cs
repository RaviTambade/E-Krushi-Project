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
    public async Task<List<Product>> Products()
    {
        List<Product> products = await _service.Products();
        return products;
    }

    [HttpGet]
    [Route("products/{id}")]
    public async Task<Product> GetProduct(int id)
    {
        Product product = await _service.GetProduct(id);
        return product;
    }

    [HttpPost]
    [Route("Insert")]

    public async Task<bool> Insert([FromBody] Product product)
    {
        bool result = await _service.Insert(product);
        return result;
    }
    
    [HttpPut]
    [Route("Update/{id}")]

    public async Task<bool> Update(int id, [FromBody] Product product)
    {
        Product oldProduct = await _service.GetProduct(id);
        if(oldProduct.Id==0){
            return false;
        }
        product.Id = id;
        bool result = await _service.Update(product);
        return result;
    }

    [HttpDelete]
    [Route("Delete/{id}")]

    public async Task<bool> Delete(int id)
    {
        bool result = await _service.Delete(id);
        return result;
    }

    [HttpGet]
    [Route("category/{categoryName}")]
    public async Task<List<Products>> CategoryName(string categoryName)
    {
        List<Products> products = await _service.CategoryName(categoryName);
        
        return products;
    }

}
using CatlogService.Models;
using CatlogService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatlogService.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }


    [HttpGet]
    [Route("getallproducts")]
    public IEnumerable<Product> GetAllProducts()
    {
        List<Product> products = _service.GetAllProducts();
        return products;
    }

    [HttpGet]
    [Route("getproduct/{id}")]
    public Product GetProduct(int id)
    {
        Product product = _service.GetProduct(id);
        return product;
    }

    [HttpPost]
    [Route("InsertProduct")]

    public bool InsertProduct([FromBody] Product product)
    {
        bool result = _service.InsertProduct(product);
        return result;
    }
    
    [HttpPut]
    [Route("UpdateProduct")]

    public bool UpdateProduct([FromBody] Product product)
    {
        bool result = _service.UpdateProduct(product);
        return result;
    }
}
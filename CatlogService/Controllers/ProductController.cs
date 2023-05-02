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
}
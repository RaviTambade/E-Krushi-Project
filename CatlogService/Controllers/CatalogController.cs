using CatlogService.Models;
using CatlogService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatlogService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly ICatalogService _service;

    public CatalogsController(ICatalogService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("/category/{categoryName}")]
    public async Task<List<Products>> GetProductsDetails(string categoryName)
    {
        List<Products> products = await _service.GetProductsDetails(categoryName);
        return products;
    }
}    
using Catalog.Models;
using Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Catalog.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        return await _service.GetProductsByCategory(categoryId);
    }
}

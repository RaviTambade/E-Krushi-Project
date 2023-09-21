using Transflower.EKrushi.Catalog.Models;
using Transflower.EKrushi.Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Transflower.EKrushi.Catalog.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<Category>> GetCategories()
    {
        return await _service.GetCategories();
    }
}

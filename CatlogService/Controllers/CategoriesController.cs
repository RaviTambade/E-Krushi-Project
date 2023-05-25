using CatlogService.Models;
using CatlogService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatlogService.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }


    [HttpGet]
    [Route("Categories")]
    public IEnumerable<Category> Categories()
    {
        List<Category> categories = _service.Categories();
        return categories;
    }

    [HttpGet]
    [Route("Categories/{id}")]
    public Category GetCategory(int id)
    {
        Category category = _service.GetCategory(id);
        return category;
    }

    [HttpPost]
    [Route("Insert")]
    public bool Insert([FromBody] Category category)
    {
        bool result = _service.Insert(category);
        return result;
    }

    [HttpPut]
    [Route("Updatecategory")]
    public bool Update([FromBody] Category category)
    {
        bool result = _service.Update(category);
        return result;
    }
    
    [HttpDelete]
    [Route("Delete/{id}")]
    public bool Delete(int id)
    {
        bool result = _service.Delete(id);
        return result;
    }

}    
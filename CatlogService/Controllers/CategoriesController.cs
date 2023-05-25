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
    [Route("getall")]
    public IEnumerable<Category> GetAllCategories()
    {
        List<Category> categories = _service.GetAllCategories();
        return categories;
    }

    [HttpGet]
    [Route("getcategory/{id}")]
    public Category GetCategory(int id)
    {
        Category category = _service.GetCategory(id);
        return category;
    }

    [HttpPost]
    [Route("Insertcategory")]
    public bool InsertCategory([FromBody] Category category)
    {
        bool result = _service.InsertCategory(category);
        return result;
    }

    [HttpPut]
    [Route("Updatecategory")]
    public bool UpdateCategory([FromBody] Category category)
    {
        bool result = _service.UpdateCategory(category);
        return result;
    }
    
    [HttpDelete]
    [Route("Deletecategory/{id}")]
    public bool DeleteCategory(int id)
    {
        bool result = _service.DeleteCategory(id);
        return result;
    }

}    
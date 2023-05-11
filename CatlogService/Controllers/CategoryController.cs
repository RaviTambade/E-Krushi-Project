using CatlogService.Models;
using CatlogService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatlogService.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
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
    [Route("Updatecategory/{id}")]
    public bool UpdateCategory(int id,[FromBody] Category category)
    {
        Category oldcategory = _service.GetCategory(id);
        if(oldcategory.CategoryId==0){
            return false;
        }
        category.CategoryId = id;
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
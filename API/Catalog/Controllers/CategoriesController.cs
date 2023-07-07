using CatalogService.Models;
using CatalogService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers;

[ApiController]
[Route("/api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

   //http://localhost:5137/api/categories
  //this  method is used for get all categories.
    [HttpGet]
    public async Task<IEnumerable<Category>> GetAll()
    {
        List<Category> categories = await _service.GetAll();
        return categories;
    }

    //http://localhost:5137/api/categories/{id}
    //this method gives category by id.
    [HttpGet]
    [Route("{id}")]
    public async Task<Category> GetById(int id)
    {
        Category category = await _service.GetById(id);
        return category;
    }

    //http://localhost:5137/api/categories
    [HttpPost]
    public async Task<bool> Insert([FromBody] Category category)
    {
        bool result =  await _service.Insert(category);
        return result;
    }

    //http://localhost:5137/api/categories
    //this method is used for update category
    [HttpPut]
    public async Task<bool> Update([FromBody] Category category)
    {
        bool result =await  _service.Update(category);
        return result;
    }
    //http://localhost:5137/api/categories/{id}
    //this method is used for delete category
    [HttpDelete]
    [Route("{id}")]
    public async Task<bool> Delete(int id)
    {
        bool result =await  _service.Delete(id);
        return result;
    }
}    


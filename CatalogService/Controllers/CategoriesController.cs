using CatalogService.Models;
using CatalogService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

  //this  method is used for get all categories.
    [HttpGet]
    [Route("Categories")]
    public async Task<IEnumerable<Category>> GetAll()
    {
        List<Category> categories = await _service.GetAll();
        return categories;
    }


   //this method gives category by id.
    [HttpGet]
    [Route("Categories/{id}")]
    public async Task<Category> GetById(int id)
    {
        Category category = await _service.GetById(id);
        return category;
    }

    [HttpPost]
    [Route("categories")]
    public async Task<bool> Insert([FromBody] Category category)
    {
        bool result =  await _service.Insert(category);
        return result;
    }

   //this method is used for update category
    [HttpPut]
    [Route("categories")]
    public async Task<bool> Update([FromBody] Category category)
    {
        bool result =await  _service.Update(category);
        return result;
    }
    
    //this method is used for delete category
    [HttpDelete]
    [Route("categories/{id}")]
    public async Task<bool> Delete(int id)
    {
        bool result =await  _service.Delete(id);
        return result;
    }
}    


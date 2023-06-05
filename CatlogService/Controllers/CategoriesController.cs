using CatlogService.Models;
using CatlogService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatlogService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogsController : ControllerBase
{
    private readonly ICatalogService _service;

    public CatalogsController(ICatalogService service)
    {
        _service = service;
    }

  //this  method is used for get all categories.
    [HttpGet]
    [Route("Categories")]
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        List<Category> categories = await _service.GetAllCategories();
        return categories;
    }


   //this method gives category by id.
    [HttpGet]
    [Route("Categories/{id}")]
    public async Task<Category> GetCategory(int id)
    {
        Category category = await _service.GetCategory(id);
        return category;
    }

    [HttpPost]
    [Route("Insert")]
    public async Task<bool> Insert([FromBody] Category category)
    {
        bool result =  await _service.Insert(category);
        return result;
    }

   //this method is used for update category
    [HttpPut]
    [Route("Update")]
    public async Task<bool> Update([FromBody] Category category)
    {
        bool result =await  _service.Update(category);
        return result;
    }
    
    //this method is used for delete category
    [HttpDelete]
    public async Task<bool> Delete(int id)
    {
        bool result =await  _service.Delete(id);
        return result;
    }
}    


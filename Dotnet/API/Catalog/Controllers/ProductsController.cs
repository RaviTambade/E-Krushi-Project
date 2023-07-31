using CatalogService.Models;
using Microsoft.AspNetCore.Mvc;
using CatalogService.Service.Interfaces;
using CatalogService.Helpers;
using System.Net.Http.Headers;

namespace CatalogService.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }
     

    // http://localhost:5137/api/products
    // this method gives list of all products.
    [HttpGet]
    public async Task<List<Product>> GetAll()
    {
        List<Product> products = await _service.GetAllProducts();
        return products;
    }

    //http://localhost:5137/api/products/product/{id}
    //this method gives product by id.
    [HttpGet("product/{id}")]
    public async Task<Product> GetById(int id)
    {
        Product product = await _service.GetProduct(id);
        return product;
    }

    //this method is used for insert product
    //http://localhost:5137/api/products
    
    [HttpPost]
    public async Task<bool> Insert([FromBody] Product product)
    {
        bool result = await _service.Insert(product);
        return result;
    }
    
    [Authorize]
    [HttpPut]
    //this method is used for Update product
    //http://localhost:5137/api/products
    public async Task<bool> Update([FromBody] Product product)
    {
        bool result =await  _service.Update(product);
        return result;
    }

    //this method is used for delete product.
    //http://localhost:5137/api/products/{id}
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<bool> DeleteProduct(int id)
    {
        bool result = await _service.DeleteProduct(id);
        return result;
    }

    //http://localhost:5137/api/products/categoryname/{categoryName} 
    [HttpGet]
    [Route("categoryname/{categoryName}")]
    public async Task<List<Product>> GetProductsDetails(string categoryName)
    {
        List<Product> products = await _service.GetProductsDetails(categoryName);
        return products;
    }
 
    //http://localhost:5137/api/products/{title}
    [HttpGet("{title}")]
    public async Task<Product> GetProductDetails(string title)
    {
        Product product = await _service.GetProductDetails(title);
        return product;
    }

    [HttpPost("updatestockavailable")]
    public async Task<bool> UpdateStockAvailable([FromBody] UpdateStockSP updateStock)
    {
        return await _service.UpdateStockAvailable(updateStock);
         
    }

    //http://localhost:5137/api/products/uploadfile
    [HttpPost ("uploadfile") , DisableRequestSizeLimit]
    public IActionResult Upload()
    {
        try
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new { dbPath });
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }
}    
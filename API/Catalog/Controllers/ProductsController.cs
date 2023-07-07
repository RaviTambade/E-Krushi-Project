using CatalogService.Models;
using Microsoft.AspNetCore.Mvc;
using CatalogService.Service.Interfaces;


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
    [HttpGet("{id}")]
    public async Task<Product> GetById(int id)
    {
        Product product = await _service.GetProduct(id);
        return product;
    }

    //this method is used for insert product

    [HttpPost]
    public async Task<bool> Insert([FromBody] Product product)
    {
        bool result = await _service.Insert(product);
        return result;
    }
    
    [HttpPut]
    //this method is used for Update product
    public async Task<bool> Update([FromBody] Product product)
    {
        bool result =await  _service.Update(product);
        return result;
    }

    //this method is used for delete product.
    [HttpDelete("{id}")]
    public async Task<bool> DeleteProduct(int id)
    {
        bool result = await _service.DeleteProduct(id);
        return result;
    }

     
    [HttpGet]
    [Route("categoryname/{categoryName}")]
    public async Task<List<Product>> GetProductsDetails(string categoryName)
    {
        List<Product> products = await _service.GetProductsDetails(categoryName);
        return products;
    }

    [HttpGet("{title}")]
    public async Task<Product> GetProductDetails(string title)
    {
        Product product = await _service.GetProductDetails(title);
        return product;
    }

}    
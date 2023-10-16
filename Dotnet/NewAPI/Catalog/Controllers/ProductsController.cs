using Transflower.EKrushi.Catalog.Models;
using Transflower.EKrushi.Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Transflower.EKrushi.Catalog.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<Product>> GetProducts()
    {
        return await _service.GetProducts();
    }

    [HttpGet("search/{productName}")]
    public async Task<List<Product>> GetSearchedProducts(string productName)
    {
        return await _service.GetSearchedProducts(productName);
    }

    [HttpGet("details/{productId:int}")]
    public async Task<ProductDetail?> GetProductdetails(int productId)
    {
        return await _service.GetProductdetails(productId);
    }

    [HttpGet("price/{productId:int}/{size}")]
    public async Task<double> GetProductPricebySize(int productId, string size)
    {
        return await _service.GetProductPricebySize(productId, size);
    }

    [HttpGet("category/{categoryId:int}")]
    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        return await _service.GetProductsByCategory(categoryId);
    }

    [HttpGet("similar/{productId:int}")]
    public async Task<List<Product>> GetSimilarProducts(int productId)
    {
        return await _service.GetSimilarProducts(productId);
    }
}

using Catalog.Models;
using Catalog.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace Catalog.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _configuration;
    private string? _connectionString;

    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        List<Product> products=null;
        return products;
    } 
}
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

    public async Task<List<Product>> GetProducts()
    {
        List<Product> products = new List<Product>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT products.id,products.title, products.image,productdetails.unitprice ,
                (SELECT GROUP_CONCAT(size) FROM productdetails  WHERE productdetails.productid = products.id) AS size_list,
                AVG(productreview.rating) AS rating FROM products
                INNER JOIN productdetails ON products.id = productdetails.productid
                INNER JOIN productreview ON products.id = productreview.productid
                GROUP BY products.id";

            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                Product product = new Product()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    UnitPrice = reader.GetDouble("unitprice"),
                    Image = reader.GetString("image"),
                    Rating = reader.GetDouble("rating"),
                    size = reader.GetString("size_list").Split(",").ToList()
                };
                products.Add(product);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return products;
    }

    public async Task<double> GetProductPricebySize(int productId, string size)
    {
        double unitprice = 0;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT productdetails.unitprice FROM productdetails
                WHERE productdetails.productid=@id AND productdetails.size=@size";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", productId);
            command.Parameters.AddWithValue("@size", size);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                unitprice = reader.GetDouble("unitprice");
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return unitprice > 0 ? unitprice : throw new InvalidOperationException();
    }

    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        List<Product> products = new List<Product>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT products.id,products.title, products.image ,
                productdetails.unitprice ,productdetails.stockavailable ,
                GROUP_CONCAT( DISTINCT productdetails.size) AS size_list,
                AVG(productreview.rating) AS ratings FROM products
                INNER JOIN productdetails ON products.id = productdetails.productid
                INNER JOIN productreview ON products.id = productreview.productid
                GROUP BY products.id";

            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? productTitle = reader["title"].ToString();
                string? image = reader["image"].ToString();
                double unitPrice = double.Parse(reader["unitprice"].ToString());

                Product product = new Product()
                {
                    Id = id,
                    Title = productTitle,
                    UnitPrice = unitPrice,
                    Image = image,
                };
                products.Add(product);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return products;
    }
}

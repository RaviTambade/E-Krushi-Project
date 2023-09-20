using Transflower.EKrushi.Catalog.Models;
using Transflower.EKrushi.Catalog.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Transflower.EKrushi.Catalog.Repositories;

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
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
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

    public async Task<List<Product>> GetSearchedProducts(string productName)
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
                WHERE products.title LIKE  CONCAT('%', @productName, '%')
                GROUP BY products.id";

            Console.WriteLine(query);
            Console.WriteLine(productName);

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@productName", productName);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
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
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
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
                @"SELECT products.id,products.title, products.image,productdetails.unitprice ,
                (SELECT GROUP_CONCAT(size) FROM productdetails  WHERE productdetails.productid = products.id) AS size_list,
                AVG(productreview.rating) AS rating FROM products
                INNER JOIN productdetails ON products.id = productdetails.productid
                INNER JOIN productreview ON products.id = productreview.productid
                WHERE products.categoryid=@categoryid
                GROUP BY products.id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@categoryid", categoryId);

            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
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

    public async Task<List<Product>> GetSimilarProducts(int productId)
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
                WHERE products.categoryid= (SELECT categoryid from products where products.id=@productid ) && products.id !=@productid
                GROUP BY products.id LIMIT 8";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@productid", productId);

            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
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

    public async Task<ProductDetail?> GetProductdetails(int productId)
    {
        ProductDetail? product = null;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT products.id,products.title,products.description ,products.image,productdetails.unitprice ,
                (SELECT GROUP_CONCAT(size) FROM productdetails  WHERE productdetails.productid = products.id) AS size_list,
                AVG(productreview.rating) AS rating FROM products
                INNER JOIN productdetails ON products.id = productdetails.productid
                INNER JOIN productreview ON products.id = productreview.productid
                WHERE products.id=@productid
                GROUP BY products.id ";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@productid", productId);

            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                product = new ProductDetail()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    UnitPrice = reader.GetDouble("unitprice"),
                    Image = reader.GetString("image"),
                    Description = reader.GetString("description"),
                    Rating = reader.GetDouble("rating"),
                    size = reader.GetString("size_list").Split(",").ToList()
                };
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
        return product;
    }
}

using Transflower.EKrushi.Catalog.Models;
using Transflower.EKrushi.Catalog.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Transflower.EKrushi.Catalog.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString =
            this._configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException("connection Sting Not Found");
    }

    public async Task<List<Product>> GetProducts()
    {
        List<Product> products = new List<Product>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT products.id,products.title, products.image,
                GROUP_CONCAT(DISTINCT productdetails.id) as productdetailsid, 
                GROUP_CONCAT(DISTINCT productdetails.unitprice) as unitprice ,
                GROUP_CONCAT( DISTINCT productdetails.size) AS sizes, 
                AVG(productreview.rating) AS rating FROM products
                INNER JOIN productdetails ON products.id = productdetails.productid
                INNER JOIN productreview ON products.id = productreview.productid
                GROUP BY products.id";

            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                List<string> productDetailsIds = reader
                    .GetString("productdetailsid")
                    .Split(",")
                    .ToList();
                List<string> UnitPrices = reader.GetString("unitprice").Split(",").ToList();
                List<string> sizes = reader.GetString("sizes").Split(",").ToList();

                var productdetails = productDetailsIds.Select(
                    (id, index) =>
                        new ProductDetail
                        {
                            ProductDetailId = id,
                            Size = sizes.ElementAt(index),
                            UnitPrice = UnitPrices.ElementAt(index)
                        }
                );

                Product product = new Product()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Image = reader.GetString("image"),
                    Rating = reader.GetDouble("rating"),
                    ProductDetails = productdetails
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
                @"SELECT products.id,products.title, products.image,
                GROUP_CONCAT(DISTINCT productdetails.id) as productdetailsid, 
                GROUP_CONCAT(DISTINCT productdetails.unitprice) as unitprice ,
                GROUP_CONCAT( DISTINCT productdetails.size) AS sizes, 
                AVG(productreview.rating) AS rating FROM products
                INNER JOIN productdetails ON products.id = productdetails.productid
                INNER JOIN productreview ON products.id = productreview.productid
                WHERE products.title LIKE  CONCAT(@productName, '%')
                GROUP BY products.id";

            Console.WriteLine(query);
            Console.WriteLine(productName);

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@productName", productName);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                List<string> productDetailsIds = reader
                    .GetString("productdetailsid")
                    .Split(",")
                    .ToList();
                List<string> UnitPrices = reader.GetString("unitprice").Split(",").ToList();
                List<string> sizes = reader.GetString("sizes").Split(",").ToList();

                var productdetails = productDetailsIds.Select(
                    (id, index) =>
                        new ProductDetail
                        {
                            ProductDetailId = id,
                            Size = sizes.ElementAt(index),
                            UnitPrice = UnitPrices.ElementAt(index)
                        }
                );

                Product product = new Product()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Image = reader.GetString("image"),
                    Rating = reader.GetDouble("rating"),
                    ProductDetails = productdetails
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
                @"SELECT products.id,products.title, products.image,
                GROUP_CONCAT(DISTINCT productdetails.id) as productdetailsid, 
                GROUP_CONCAT(DISTINCT productdetails.unitprice) as unitprice ,
                GROUP_CONCAT( DISTINCT productdetails.size) AS sizes, 
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
                List<string> productDetailsIds = reader
                    .GetString("productdetailsid")
                    .Split(",")
                    .ToList();
                List<string> UnitPrices = reader.GetString("unitprice").Split(",").ToList();
                List<string> sizes = reader.GetString("sizes").Split(",").ToList();

                var productdetails = productDetailsIds.Select(
                    (id, index) =>
                        new ProductDetail
                        {
                            ProductDetailId = id,
                            Size = sizes.ElementAt(index),
                            UnitPrice = UnitPrices.ElementAt(index)
                        }
                );

                Product product = new Product()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Image = reader.GetString("image"),
                    Rating = reader.GetDouble("rating"),
                    ProductDetails = productdetails
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
                @"SELECT products.id,products.title, products.image,
                GROUP_CONCAT(DISTINCT productdetails.id) as productdetailsid, 
                GROUP_CONCAT(DISTINCT productdetails.unitprice) as unitprice ,
                GROUP_CONCAT( DISTINCT productdetails.size) AS sizes, 
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
                List<string> productDetailsIds = reader
                    .GetString("productdetailsid")
                    .Split(",")
                    .ToList();
                List<string> UnitPrices = reader.GetString("unitprice").Split(",").ToList();
                List<string> sizes = reader.GetString("sizes").Split(",").ToList();

                var productdetails = productDetailsIds.Select(
                    (id, index) =>
                        new ProductDetail
                        {
                            ProductDetailId = id,
                            Size = sizes.ElementAt(index),
                            UnitPrice = UnitPrices.ElementAt(index)
                        }
                );

                Product product = new Product()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Image = reader.GetString("image"),
                    Rating = reader.GetDouble("rating"),
                    ProductDetails = productdetails
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

    public async Task<ProductDescription?> GetProductdetails(int productId)
    {
        ProductDescription? product = null;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT products.id,products.title,products.description, products.image,
                GROUP_CONCAT(DISTINCT productdetails.id) as productdetailsid, 
                GROUP_CONCAT(DISTINCT productdetails.unitprice) as unitprice ,
                GROUP_CONCAT( DISTINCT productdetails.size) AS sizes, 
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
                List<string> productDetailsIds = reader
                    .GetString("productdetailsid")
                    .Split(",")
                    .ToList();
                List<string> UnitPrices = reader.GetString("unitprice").Split(",").ToList();
                List<string> sizes = reader.GetString("sizes").Split(",").ToList();

                var productdetails = productDetailsIds.Select(
                    (id, index) =>
                        new ProductDetail
                        {
                            ProductDetailId = id,
                            Size = sizes.ElementAt(index),
                            UnitPrice = UnitPrices.ElementAt(index)
                        }
                );

                product = new ProductDescription()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Image = reader.GetString("image"),
                    Description = reader.GetString("description"),
                    Rating = reader.GetDouble("rating"),
                    ProductDetails = productdetails
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

    public async Task<List<string>> GetProductNameSuggestions(string searchString)
    {
        List<string> productNames = new();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT products.title FROM products  WHERE products.title LIKE CONCAT(@searchString, '%') LIMIT 5 ";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchString", searchString);

            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                productNames.Add(reader.GetString("title"));
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
        return productNames;
    }

    public async Task<List<Product>> GetProductsBySupplier(int supplierId)
    {
        List<Product> products = new List<Product>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT products.id,products.title, products.image,
                GROUP_CONCAT(DISTINCT productdetails.id) as productdetailsid, 
                GROUP_CONCAT(DISTINCT productdetails.unitprice) as unitprice ,
                GROUP_CONCAT( DISTINCT productdetails.size) AS sizes, 
                AVG(productreview.rating) AS rating FROM products
                INNER JOIN productdetails ON products.id = productdetails.productid
                INNER JOIN productreview ON products.id = productreview.productid
                WHERE productdetails.supplierid= @supplierid
                GROUP BY products.id ";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@supplierid", supplierId);

            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                List<string> productDetailsIds = reader
                    .GetString("productdetailsid")
                    .Split(",")
                    .ToList();
                List<string> UnitPrices = reader.GetString("unitprice").Split(",").ToList();
                List<string> sizes = reader.GetString("sizes").Split(",").ToList();

                var productdetails = productDetailsIds.Select(
                    (id, index) =>
                        new ProductDetail
                        {
                            ProductDetailId = id,
                            Size = sizes.ElementAt(index),
                            UnitPrice = UnitPrices.ElementAt(index)
                        }
                );

                Product product = new Product()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Image = reader.GetString("image"),
                    Rating = reader.GetDouble("rating"),
                    ProductDetails = productdetails
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

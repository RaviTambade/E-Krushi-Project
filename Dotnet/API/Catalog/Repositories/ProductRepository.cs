using Transflower.EKrushi.Catalog.Models;
using MySql.Data.MySqlClient;
using Transflower.EKrushi.Catalog.Repositories.Interfaces;
using System.Data;

namespace Transflower.EKrushi.Catalog.Repositories;

    public class ProductRepository : IProductRepository
    {
        private IConfiguration _configuration;
        private string? _connectionString;
    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from products";
                MySqlCommand command  = new MySqlCommand(query,connection);
                await connection.OpenAsync();
                MySqlDataReader reader = command .ExecuteReader();
                while(await reader.ReadAsync())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string? productTitle = reader["title"].ToString();
                    double unitPrice = double.Parse(reader["unitprice"].ToString());
                    int stockAvailable = int.Parse(reader["stockavailable"].ToString());
                    string? image = reader["image"].ToString();
                    int categoryId = int.Parse(reader["categoryid"].ToString());

                    Product product = new Product()
                    {
                        Id = id,
                        Title = productTitle,
                        UnitPrice = unitPrice,
                        StockAvailable = stockAvailable,
                        Image = image,
                        CategoryId = categoryId

                    };
                    products.Add(product);
                }
                await reader.CloseAsync();
            }
            catch(Exception){
                throw;
            }
            finally{
                await connection.CloseAsync();
            }
            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = new Product();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try{
                string query = "select * from products where id = @productId";
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@productId",id);
                await connection.OpenAsync();
                MySqlDataReader reader = command .ExecuteReader();
                while(await reader.ReadAsync())
                {
                    string productTitle = reader["title"].ToString();
                    double unitPrice = double.Parse(reader["unitprice"].ToString());
                    int stockAvailable = int.Parse(reader["stockavailable"].ToString());
                    string image = reader["image"].ToString();
                    int categoryId = int.Parse(reader["categoryid"].ToString());

                    product = new Product()
                    {
                        Id = id,
                        Title = productTitle,
                        UnitPrice = unitPrice,
                        StockAvailable = stockAvailable,
                        Image = image,
                        CategoryId = categoryId

                    };

                }
                await reader.CloseAsync();
            }
            catch(Exception){
                throw ;
            }
            finally{
                await connection.CloseAsync();
            }
            return product;
        }
        public async Task<bool> Insert(Product product)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query="Insert into products(title,unitprice,stockavailable,image,categoryid) VALUES(@productTitle,@unitPrice,@stockAvailable,@image,@categoryId)";
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@productTitle",product.Title);
                command .Parameters.AddWithValue("@unitPrice",product.UnitPrice);
                command .Parameters.AddWithValue("@stockAvailable",product.StockAvailable);
                command .Parameters.AddWithValue("@image",product.Image);
                command .Parameters.AddWithValue("@categoryId",product.CategoryId);
                await connection.OpenAsync();
                int rowsAffected = command .ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }

        public async Task<bool> Update(Product product)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query="Update products set title=@productTitle, unitprice = @unitPrice, stockavailable = @stockAvailable, image = @image ,categoryid = @categoryId Where id = @productId";
                MySqlCommand command  = new MySqlCommand(query,connection);
                await connection.OpenAsync();
                command .Parameters.AddWithValue("@productId",product.Id);
                command .Parameters.AddWithValue("@productTitle",product.Title);
                command .Parameters.AddWithValue("@unitPrice",product.UnitPrice);
                command .Parameters.AddWithValue("@stockAvailable",product.StockAvailable);
                command .Parameters.AddWithValue("@image",product.Image);
                command .Parameters.AddWithValue("@categoryId",product.CategoryId);
                int rowsAffected = command .ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }
        public async Task<bool>  DeleteProduct(int id)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query="Delete from products where id = @productId";
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@productId",id);
                await connection.OpenAsync();
                int rowsAffected = command .ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }
    

    public async Task<List<Product>> GetProductsDetails(string categoryName)
    {
        
           List<Product> products = new List<Product>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try{
                string query = "SELECT products.id, products.title,products.unitprice,products.stockavailable,products.image,categories.title from categories inner join products where categories.id=products.categoryid and categories.title=@categoryName";
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@categoryName",categoryName);
                await connection.OpenAsync();
                MySqlDataReader reader = command .ExecuteReader();
                while(await reader.ReadAsync())
                {
                    int productId = int.Parse(reader["id"].ToString());
                    string productTitle = reader["title"].ToString();
                    double unitPrice = double.Parse(reader["unitprice"].ToString());
                    int stockAvailable = int.Parse(reader["stockavailable"].ToString());
                    string image = reader["image"].ToString();
                    string categoryTitle = reader["title"].ToString();

                    Product product = new Product()
                    {
                        Id = productId,
                        Title = productTitle,
                        UnitPrice = unitPrice,
                        StockAvailable = stockAvailable,
                        Image = image,
                        CategoryTitle = categoryTitle

                    };
                    products.Add(product);
                   
                }
                 await reader.CloseAsync();
                
            }
            catch(Exception){
                throw;
            }
            finally{
                await connection.CloseAsync();
            }
            return products;
        }


     public async Task<Product> GetProductDetails(string title)
        {
            Product product = new Product();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try{
                string query = "select * from products where title = @title";
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@title",title);
                await connection.OpenAsync();
                MySqlDataReader reader = command .ExecuteReader();
                while(await reader.ReadAsync())
                {   int id =int.Parse(reader["id"].ToString());
                    string productTitle = reader["title"].ToString();
                    double unitPrice = double.Parse(reader["unitprice"].ToString());
                    int stockAvailable = int.Parse(reader["stockavailable"].ToString());
                    string image = reader["image"].ToString();
                    int categoryId = int.Parse(reader["categoryid"].ToString());

                    product = new Product()
                    {
                        Id=id,
                        Title = productTitle,
                        UnitPrice = unitPrice,
                        StockAvailable = stockAvailable,
                        Image = image,
                        CategoryId = categoryId

                    };

                }
                await reader.CloseAsync();
            }
            catch(Exception){
                throw;
            }
            finally{
                await connection.CloseAsync();
            }
            return product;
        }

    public async Task<bool> UpdateStockAvailable(Procedure updateStock)
        {
            
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                MySqlCommand command  = new MySqlCommand("stockavailableupdateinventory",connection);
                command .CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                command .Parameters.AddWithValue("@orderid",updateStock.OrderId);
                command .Parameters.AddWithValue("@productid",updateStock.ProductId);
                command .Parameters.AddWithValue("@quantity",updateStock.Quantity); 
                int rowsAffected = command .ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }
         
    }
    
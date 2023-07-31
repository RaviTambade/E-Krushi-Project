using CatalogService.Models;
using MySql.Data.MySqlClient;
using CatalogService.Repositories.Interfaces;
using System.Data;

namespace CatalogService.Repositories
{

    public class ProductRepository : IProductRepository
    {
    private IConfiguration _configuration;
    private string? _conString;
    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                string query = "select * from products";
                MySqlCommand cmd = new MySqlCommand(query,con);
                await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
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
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = new Product();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from products where id = @productId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@productId",id);
                await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
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
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return product;
        }
        public async Task<bool> Insert(Product product)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                string query="Insert into products(title,unitprice,stockavailable,image,categoryid) VALUES(@productTitle,@unitPrice,@stockAvailable,@image,@categoryId)";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@productTitle",product.Title);
                cmd.Parameters.AddWithValue("@unitPrice",product.UnitPrice);
                cmd.Parameters.AddWithValue("@stockAvailable",product.StockAvailable);
                cmd.Parameters.AddWithValue("@image",product.Image);
                cmd.Parameters.AddWithValue("@categoryId",product.CategoryId);
                await con.OpenAsync();
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                await con.CloseAsync();
            }
            return status;
        }

        public async Task<bool> Update(Product product)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                string query="Update products set title=@productTitle, unitprice = @unitPrice, stockavailable = @stockAvailable, image = @image ,categoryid = @categoryId Where id = @productId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                await con.OpenAsync();
                cmd.Parameters.AddWithValue("@productId",product.Id);
                cmd.Parameters.AddWithValue("@productTitle",product.Title);
                cmd.Parameters.AddWithValue("@unitPrice",product.UnitPrice);
                cmd.Parameters.AddWithValue("@stockAvailable",product.StockAvailable);
                cmd.Parameters.AddWithValue("@image",product.Image);
                cmd.Parameters.AddWithValue("@categoryId",product.CategoryId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                await con.CloseAsync();
            }
            return status;
        }
        public async Task<bool>  DeleteProduct(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                string query="Delete from products where id = @productId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@productId",id);
                await con.OpenAsync();
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                await con.CloseAsync();
            }
            return status;
        }
    

    public async Task<List<Product>> GetProductsDetails(string categoryName)
    {
        
           List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "SELECT products.id, products.title,products.unitprice,products.stockavailable,products.image,categories.title from categories inner join products where categories.id=products.categoryid and categories.title=@categoryName";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryName",categoryName);
                await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
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
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return products;
        }


     public async Task<Product> GetProductDetails(string title)
        {
            Product product = new Product();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from products where title = @title";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@title",title);
                await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
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
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return product;
        }

    public async Task<bool> UpdateStockAvailable(UpdateStockSP updateStock)
        {
            Console.WriteLine(updateStock.OrderId);
            Console.WriteLine(updateStock.ProductId);
            Console.WriteLine(updateStock.Quantity);

            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                MySqlCommand cmd = new MySqlCommand("stockavailableupdateinventory",con);
                cmd.CommandType = CommandType.StoredProcedure;
                await con.OpenAsync();
                cmd.Parameters.AddWithValue("@orderid",updateStock.OrderId);
                cmd.Parameters.AddWithValue("@productid",updateStock.ProductId);
                cmd.Parameters.AddWithValue("@quantity",updateStock.Quantity); 
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                await con.CloseAsync();
            }
            return status;
        }
    }
}
    
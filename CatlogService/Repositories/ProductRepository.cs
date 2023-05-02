using CatlogService.Models;
using CatlogService.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace CatlogService.Repositories
{

    public class ProductRepository:IProductRepository{

    public static string conString = "server=localhost; port=3306; user=root; password=Password; database=E_Krushi";

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "select * from products";
                MySqlCommand cmd = new MySqlCommand(query,con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    int productId = int.Parse(reader["product_id"].ToString());
                    string title = reader["product_title"].ToString();
                    double unitPrice = double.Parse(reader["unit_price"].ToString());
                    int stockAvailable = int.Parse(reader["stock_available"].ToString());
                    string image = reader["image"].ToString();
                    int categoryId = int.Parse(reader["category_id"].ToString());

                    Product product = new Product()
                    {
                        ProductId = productId,
                        Title = title,
                        UnitPrice = unitPrice,
                        StockAvailable = stockAvailable,
                        Image = image,
                        CategoryId = categoryId

                    };
                    products.Add(product);
                }
                reader.Close();
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return products;
        }

        public Product GetProduct(int productId)
        {
            Product product = new Product();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try{
                string query = "select * from products where product_id = @productId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@productId",productId);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string title = reader["product_title"].ToString();
                    double unitPrice = double.Parse(reader["unit_price"].ToString());
                    int stockAvailable = int.Parse(reader["stock_available"].ToString());
                    string image = reader["image"].ToString();
                    int categoryId = int.Parse(reader["category_id"].ToString());

                    product = new Product()
                    {
                        ProductId = productId,
                        Title = title,
                        UnitPrice = unitPrice,
                        StockAvailable = stockAvailable,
                        Image = image,
                        CategoryId = categoryId

                    };

                }
                reader.Close();
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return product;
        }
        public bool InsertProduct(Product product)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query="Insert into products(product_title,unit_price,stock_available,image,category_id) VALUES(@productTitle,@unitPrice,@stockAvailable,@image,@categoryId)";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@productTitle",product.Title);
                cmd.Parameters.AddWithValue("@unitPrice",product.UnitPrice);
                cmd.Parameters.AddWithValue("@stockAvailable",product.StockAvailable);
                cmd.Parameters.AddWithValue("@image",product.Image);
                cmd.Parameters.AddWithValue("@categoryId",product.CategoryId);
                con.Open();
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
                con.Close();
            }
            return status;
        }

        public bool UpdateProduct(Product product)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query="Update products set product_title=@producttitle, unit_price = @unitPrice, stock_available = @stockAvailable, image = @image, category_id = @categoryId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@productId",product.ProductId);
                cmd.Parameters.AddWithValue("@productTitle",product.Title);
                cmd.Parameters.AddWithValue("@unitPrice",product.UnitPrice);
                cmd.Parameters.AddWithValue("@stockAvailable",product.StockAvailable);
                cmd.Parameters.AddWithValue("@image",product.Image);
                cmd.Parameters.AddWithValue("@categoryId",product.CategoryId);
                con.Open();
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
                con.Close();
            }
            return status;
        }
        public bool DeleteProduct(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query="Delete from products where product_id = @productId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@productId",id);
                con.Open();
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
                con.Close();
            }
            return status;
        }
    }
}
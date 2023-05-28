using CatlogService.Models;
using CatlogService.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace CatlogService.Repositories
{

    public class ProductRepository:IProductRepository{

     private IConfiguration _configuration;
    private string _conString;
    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

        public List<Product> Products()
        {
            List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                string query = "select * from products";
                MySqlCommand cmd = new MySqlCommand(query,con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string productTitle = reader["title"].ToString();
                    double unitPrice = double.Parse(reader["unitprice"].ToString());
                    int stockAvailable = int.Parse(reader["stockavailable"].ToString());
                    string image = reader["image"].ToString();
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

        public Product GetProduct(int id)
        {
            Product product = new Product();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from products where id = @productId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@productId",id);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
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
        public bool Insert(Product product)
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

        public bool Update(Product product)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                string query="Update products set title=@productTitle, unitprice = @unitPrice, stockavailable = @stockAvailable, image = @image ,categoryid = @categoryId Where id = @productId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                con.Open();
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
                con.Close();
            }
            return status;
        }
        public bool Delete(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                string query="Delete from products where id = @productId";
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
    
    
    public List<Products> CategoryName(string categoryName)
    {
        
           List<Products> products = new List<Products>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "SELECT products.product_id, products.product_title,products.unit_price,products.stock_available,products.image,categories.category_title from categories inner join products where categories.category_id=products.category_id and categories.category_title=@seeds";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@seeds",categoryName);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    int productId = int.Parse(reader["product_id"].ToString());
                    string productTitle = reader["product_title"].ToString();
                    double unitPrice = double.Parse(reader["unit_price"].ToString());
                    int stockAvailable = int.Parse(reader["stock_available"].ToString());
                    string image = reader["image"].ToString();
                    string categoryTitle = reader["category_title"].ToString();

                    Products product = new Products()
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

    }
}


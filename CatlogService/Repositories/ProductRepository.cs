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
    }
}
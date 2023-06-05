
using CatlogService.Models;
using CatlogService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace CatlogService.Repositories{

public class CatalogRepository : ICatalogRepository
    {
        private IConfiguration _configuration;
    private string _conString;
    public CatalogRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<List<Products>> GetProductsDetails(string categoryName)
    {
        
           List<Products> products = new List<Products>();
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

    
    }
}

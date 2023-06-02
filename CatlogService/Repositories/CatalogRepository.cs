
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
       

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
        try{
            string query = "select * from categories";
            MySqlCommand cmd = new MySqlCommand(query,con);
           await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while( await reader.ReadAsync())
            {
                int categoryId = int.Parse(reader["id"].ToString());
                string categoryTitle = reader["title"].ToString();
                string description = reader["description"].ToString();
                string image = reader["image"].ToString();
            
            Category category = new Category()
            {
                Id = categoryId,
                Title= categoryTitle,
                Description = description,
                Image = image
            };
            categories.Add(category);
            }
           await reader.CloseAsync();
        }
        catch(Exception e){
            throw e;
        }
        finally{
            con.Close();
        }
        return categories;
        }
        public async Task<Category> GetCategory(int id)
        {
            Category category = new Category();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from categories where id = @categoryId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryId",id);
               await  con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(await reader.ReadAsync())
                {
                    int categoryId = int.Parse(reader["id"].ToString());
                    string categoryTitle = reader["title"].ToString();
                    string description = reader["description"].ToString();
                    string image = reader["image"].ToString();
                    
                category = new Category()
                {
                    Id = categoryId,
                    Title= categoryTitle,
                    Description = description,
                    Image = image

                };
               await reader.CloseAsync();
            }
            }
            catch(Exception e){
                throw e;
            }
            finally{
               await con.CloseAsync();
            }
            return category;
        }

        public async Task<bool> Insert(Category category)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Insert into categories(title,description,image) VALUES(@categoryTitle,@description,@image)";
                 await con.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryTitle",category.Title);
                cmd.Parameters.AddWithValue("@description",category.Description);
                cmd.Parameters.AddWithValue("@image",category.Image);
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                 await con.CloseAsync();
            }
            return status;
        }
        public async Task<bool> Update(Category category)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Update categories set title = @categoryTitle, description= @description, image = @image where id = @categoryId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryId",category.Id);
                cmd.Parameters.AddWithValue("@categoryTitle",category.Title);
                cmd.Parameters.AddWithValue("@description",category.Description);
                cmd.Parameters.AddWithValue("@image",category.Image);
                await con.OpenAsync();
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e){
                throw e;
            }
            finally{
               await con.CloseAsync();
            }
            return status;
        }
        public async Task<bool> Delete(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Delete from categories Where id = @categoryId";
                await con.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryId",id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return status;
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
    
    
    public async Task<List<Products>> GetProductsDetails(string categoryName)
    {
        
           List<Products> products = new List<Products>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "SELECT products.product_id, products.product_title,products.unit_price,products.stock_available,products.image,categories.category_title from categories inner join products where categories.category_id=products.category_id and categories.category_title=@seeds";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@seeds",categoryName);
                await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(await reader.ReadAsync())
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

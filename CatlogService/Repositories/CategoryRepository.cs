
using CatlogService.Models;
using CatlogService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace CatlogService.Repositories{

public class CategoryRepository : ICategoryRepository
    {
        private IConfiguration _configuration;
    private string _conString;
    public CategoryRepository(IConfiguration configuration)
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
    }
}


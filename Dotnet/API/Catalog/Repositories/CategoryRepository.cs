using Transflower.EKrushi.Catalog.Models;
using Transflower.EKrushi.Catalog.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Transflower.EKrushi.Catalog.Repositories{

public class CategoryRepository : ICategoryRepository
    {
        private IConfiguration _configuration;
    private string? _connectionString;
    public CategoryRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }
       

        public async Task<List<Category>> GetAll()
        {
            List<Category> categories = new List<Category>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
        try{
            string query = "select * from categories";
            MySqlCommand  command = new MySqlCommand(query,connection);
           await connection.OpenAsync();
            MySqlDataReader reader = command .ExecuteReader();
            while( await reader.ReadAsync())
            {
                int categoryId = Int32.Parse(reader["id"].ToString());
                string? categoryTitle = reader["title"].ToString();
                string? description = reader["description"].ToString();
                string? image = reader["image"].ToString();
            
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
        catch(Exception){
            throw;
        }
        finally{
            connection.Close();
        }
        return categories;
        }
        public async Task<Category> GetById(int id)
        {
            Category category = new Category();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try{
                string query = "select * from categories where id = @categoryId";
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@categoryId",id);
               await  connection.OpenAsync();
                MySqlDataReader reader = command .ExecuteReader();
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
            catch(Exception){
                throw;
            }
            finally{
               await connection.CloseAsync();
            }
            return category;
        }

        public async Task<bool> Insert(Category category)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try{
                string query = "Insert into categories(title,description,image) VALUES(@categoryTitle,@description,@image)";
                 await connection.OpenAsync();
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@categoryTitle",category.Title);
                command .Parameters.AddWithValue("@description",category.Description);
                command .Parameters.AddWithValue("@image",category.Image);
                int rowsAffected = command .ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception){
                throw;
            }
            finally{
                 await connection.CloseAsync();
            }
            return status;
        }
        public async Task<bool> Update(Category category)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try{
                string query = "Update categories set title = @categoryTitle, description= @description, image = @image where id = @categoryId";
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@categoryId",category.Id);
                command .Parameters.AddWithValue("@categoryTitle",category.Title);
                command .Parameters.AddWithValue("@description",category.Description);
                command .Parameters.AddWithValue("@image",category.Image);
                await connection.OpenAsync();
                int rowsAffected = command .ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception){
                throw;
            }
            finally{
               await connection.CloseAsync();
            }
            return status;
        }
        public async Task<bool> Delete(int id)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try{
                string query = "Delete from categories Where id = @categoryId";
                await connection.OpenAsync();
                MySqlCommand command  = new MySqlCommand(query,connection);
                command .Parameters.AddWithValue("@categoryId",id);
                int rowsAffected = command .ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception){
                throw;
            }
            finally{
                await connection.CloseAsync();
            }
            return status;
        }
    
    }
}
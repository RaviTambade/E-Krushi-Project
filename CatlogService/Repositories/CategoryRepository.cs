
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
       

        public List<Category> Categories()
        {
            List<Category> categories = new List<Category>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
        try{
            string query = "select * from categories";
            MySqlCommand cmd = new MySqlCommand(query,con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int categoryId = int.Parse(reader["category_id"].ToString());
                string categoryTitle = reader["category_title"].ToString();
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
            reader.Close();
        }
        catch(Exception e){
            throw e;
        }
        finally{
            con.Close();
        }
        return categories;
        }
        public Category GetCategory(int id)
        {
            Category category = new Category();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from categories where category_id = @categoryId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryId",id);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    int categoryId = int.Parse(reader["category_id"].ToString());
                    string categoryTitle = reader["category_title"].ToString();
                    string description = reader["description"].ToString();
                    string image = reader["image"].ToString();
                    
                category = new Category()
                {
                    Id = categoryId,
                    Title= categoryTitle,
                    Description = description,
                    Image = image

                };
                reader.Close();
            }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return category;
        }

        public bool Insert(Category category)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Insert into categories(category_title,description,image) VALUES(@categoryTitle,@description,@image)";
                con.Open();
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
                con.Close();
            }
            return status;
        }
        public bool Update(Category category)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Update categories set category_title = @categoryTitle, description= @description, image = @image where category_id = @categoryId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryId",category.Id);
                cmd.Parameters.AddWithValue("@categoryTitle",category.Title);
                cmd.Parameters.AddWithValue("@description",category.Description);
                cmd.Parameters.AddWithValue("@image",category.Image);
                con.Open();
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
                con.Close();
            }
            return status;
        }
        public bool Delete(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Delete from categories Where category_id = @categoryId";
                con.Open();
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
                con.Close();
            }
            return status;
        }
    }
}


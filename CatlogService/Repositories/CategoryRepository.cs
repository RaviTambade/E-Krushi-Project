
using CatlogService.Models;
using CatlogService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace CatlogService.Repositories{

public class CategoryRepository : ICategoryRepository
    {
        public static string conString = "server=localhost; port=3306; user=root; password=Password; database=E_Krushi";
       

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
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
                CategoryId = categoryId,
                CategoryTitle= categoryTitle,
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
            con.ConnectionString = conString;
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
                    CategoryId = categoryId,
                    CategoryTitle= categoryTitle,
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

        public bool InsertCategory(Category category)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try{
                string query = "Insert into categories(category_title,description,image) VALUES(@categoryTitle,@description,@image)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryTitle",category.CategoryTitle);
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
        public bool UpdateCategory(Category category)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try{
                string query = "Update categories set category_title = @categoryTitle, description= @description, image = @image where category_id = @categoryId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@categoryId",category.CategoryId);
                cmd.Parameters.AddWithValue("@categoryTitle",category.CategoryTitle);
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
        public bool DeleteCategory(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
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


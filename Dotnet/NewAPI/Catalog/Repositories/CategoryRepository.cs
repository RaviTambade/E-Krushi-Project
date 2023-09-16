using Catalog.Models;
using Catalog.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Catalog.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IConfiguration _configuration;
    private string? _connectionString;

    public CategoryRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<Category>> GetCategories()
    {
        List<Category> categories = new List<Category>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT * FROM categories";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int categoryId = Int32.Parse(reader["id"].ToString());
                string? categoryTitle = reader["title"].ToString();
                string? image = reader["image"].ToString();

                Category category = new Category()
                {
                    Id = categoryId,
                    Title = categoryTitle,
                    Image = image
                };
                categories.Add(category);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return categories;
    }
}

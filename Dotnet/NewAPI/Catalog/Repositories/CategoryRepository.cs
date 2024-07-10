using Transflower.EKrushi.Catalog.Models;
using Transflower.EKrushi.Catalog.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Transflower.EKrushi.Catalog.Repositories;

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
            string query = "SELECT * FROM categories LIMIT 6";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                Category category = new Category()
                {
                    Id = reader.GetInt32("id"),
                    Title = reader.GetString("title"),
                    Image = reader.GetString("image")
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

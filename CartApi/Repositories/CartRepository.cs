using System.Data;
using MySql.Data.MySqlClient;
using ShoppingCartService.Models;
using ShoppingCartService.Repositories.Interfaces;
namespace ShoppingCartService.Repositories;
public class CartRepository : ICartRepository
{
    private IConfiguration _configuration;
    private string _conString;
    public CartRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<bool> AddItem(int cartId, Item item)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        try
        {
            con.ConnectionString = _conString;
            await con.OpenAsync();
            string query = "INSERT into cart_items(cart_id,product_id,quantity) VALUES (@cartId, @productId,@quantity)";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@cartId", cartId);
            command.Parameters.AddWithValue("@productId", item.Id);
            command.Parameters.AddWithValue("@quantity", item.Quantity);
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected >= 1)
            {
                status = true;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }
}
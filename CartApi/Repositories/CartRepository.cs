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

    public async Task<Cart> GetCart(int id)
    {
        Cart cart = new Cart();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT products.title,products.image,products.unitprice,cartitems.quantity,cartitems.productid FROM products inner join cartitems on products.id=cartitems.productid where cartitems.cartid=@cartId";
            
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@cartId", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int productId = int.Parse(reader["productid"].ToString());
                string productTitle = reader["title"].ToString();
                string imageURL = reader["image"].ToString();
                int quantity = int.Parse(reader["quantity"].ToString());
                double unitPrice = double.Parse(reader["unitprice"].ToString());
                Item item = new Item()
                {
                    Id = productId,
                    Title = productTitle,
                    Image = imageURL,
                    Quantity = quantity,
                    UnitPrice = unitPrice
                };
                cart.Items.Add(item);
                cart.CartId = id;
            }
            await reader.CloseAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return cart;
    }



    public async Task<bool> AddItem(int cartId, Item item)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        try
        {
            con.ConnectionString = _conString;
            await con.OpenAsync();
            string query = "INSERT into cartitems(cartid,productid,quantity) VALUES (@cartId, @productId,@quantity)";
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
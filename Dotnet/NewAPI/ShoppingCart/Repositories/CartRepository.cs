using MySql.Data.MySqlClient;
using Transflower.EKrushi.ShoppingCartService.Models;
using Transflower.EKrushi.ShoppingCartService.Repositories.Interfaces;

namespace Transflower.EKrushi.ShoppingCartService.Repositories;

public class CartRepository : ICartRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _conString;

    public CartRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString =
            _configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(_conString));
    }

    public async Task<List<Item>> GetCartItems(int customerId)
    {
        List<Item> items = new();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query =
                @"SELECT cartitems.id,cartitems.cartid,cartitems.quantity,
                products.id as productid,products.title,products.image,
                productdetails.unitprice,productdetails.size FROM cartitems
                INNER JOIN carts ON carts.id=cartitems.cartid 
                INNER JOIN productdetails ON productdetails.id=cartitems.productdetailsid
                INNER JOIN products ON products.id=productdetails.productid 
                WHERE carts.customerid=@customerid";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerid", customerId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                int cartItemId = reader.GetInt32("id");
                string productTitle = reader.GetString("title");
                string image = reader.GetString("image");
                string size = reader.GetString("size");
                int productId = reader.GetInt32("productid");
                int quantity = reader.GetInt32("quantity");
                double unitPrice = reader.GetDouble("unitprice");

                Item item = new Item()
                {
                    CartItemId = cartItemId,
                    ProductId = productId,
                    Title = productTitle,
                    Image = image,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    Size = size
                };
                items.Add(item);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return items;
    }

    public async Task<bool> UpdateItemQuantity(int cartItemId, int quantity)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query =
                "UPDATE cartitems SET quantity=@quantity where cartitems.id = @cartItemId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@cartItemId", cartItemId);
            command.Parameters.AddWithValue("@quantity", quantity);
            await connection.OpenAsync();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }

    public async Task<bool> RemoveItem(int cartItemId)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM cartitems WHERE id = @cartItemId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@cartItemId", cartItemId);
            await connection.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }

    public async Task<bool> AddItem(CartItem item)
    {
        bool status = false;

        MySqlConnection connection = new MySqlConnection();
        try
        {
            connection.ConnectionString = _conString;
            await connection.OpenAsync();
            string query =
                @"INSERT INTO cartitems (cartid, productdetailsid, quantity) VALUES ( 
                (SELECT id FROM carts WHERE customerid = @customerid),
                (SELECT id FROM productdetails WHERE productid = @productid AND size = @size), 1)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@productid", item.ProductId);
            command.Parameters.AddWithValue("@customerid", item.CustomerId);
            command.Parameters.AddWithValue("@size", item.Size);
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected >= 1)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }

    public async Task<bool> IsProductInCart(CartItem item)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query =
                @"SELECT EXISTS (SELECT  cartitems.id from  cartitems   
            INNER JOIN carts on carts.id = cartitems.cartid
            WHERE carts.customerid=@customerid  AND cartitems.productdetailsid = 
            (SELECT id FROM productdetails WHERE productid=@productid and size=@size ))";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@productid", item.ProductId);
            command.Parameters.AddWithValue("@customerid", item.CustomerId);
            command.Parameters.AddWithValue("@size", item.Size);
            await connection.OpenAsync();
            var isExists = await command.ExecuteScalarAsync();
            if (isExists != null && (long)isExists == 1)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }

    public async Task<bool> RemoveAllCartItems(int customerId)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = @"DELETE FROM cartitems WHERE 
            cartid = (SELECT id FROM carts where carts.customerid=@customerid)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerid", customerId);
            await connection.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }
}

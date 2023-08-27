using System.Data;
using MySql.Data.MySqlClient;
using Transflower.EKrushi.ShoppingCartService.Models;
using Transflower.EKrushi.ShoppingCartService.Repositories.Interfaces;
namespace Transflower.EKrushi.ShoppingCartService.Repositories;
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
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "SELECT products.title,products.image,products.unitprice,cartitems.quantity,cartitems.productid,cartitems.cartid FROM products inner join cartitems on products.id=cartitems.productid where cartitems.cartid=@cartId";

            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@cartId", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int productId = int.Parse(reader["productid"].ToString());
                int cartId = int.Parse(reader["cartid"].ToString());
                string productTitle = reader["title"].ToString();
                string imageURL = reader["image"].ToString();
                int quantity = int.Parse(reader["quantity"].ToString());
                double unitPrice = double.Parse(reader["unitprice"].ToString());
                Item item = new Item()
                {
                    ProductId = productId,
                    CartId = cartId,
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
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return cart;
    }



    public async Task<bool> AddItem(Item item)
    {
        bool status = false;
        Console.WriteLine(item.CartId);
        Console.WriteLine(item.ProductId);
        Console.WriteLine(item.Quantity);
        MySqlConnection connection = new MySqlConnection();
        try
        {
            connection.ConnectionString = _conString;
            await connection.OpenAsync();
            string query = "INSERT into cartitems(cartid,productid,quantity) VALUES (@cartid,@productId,@quantity)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@cartid", item.CartId);
            command.Parameters.AddWithValue("@productId", item.ProductId);
            command.Parameters.AddWithValue("@quantity", item.Quantity);
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

    public async Task<Cart> GetAll(int custId)
    {
        Cart cart = new Cart();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT carts.custid,cartitems.cartid, products.title,products.image,products.unitprice,cartitems.quantity,cartitems.productid,carts.custid FROM products inner join " +
                           "cartitems on products.id=cartitems.productid inner join carts on carts.id=cartitems.cartid where carts.custid=@custId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@custId", custId);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int productId = int.Parse(reader["productid"].ToString());
                int cartId = int.Parse(reader["cartid"].ToString());
                string productTitle = reader["title"].ToString();
                string imageURL = reader["image"].ToString();
                int quantity = int.Parse(reader["quantity"].ToString());
                double unitPrice = double.Parse(reader["unitprice"].ToString());

                Item item = new Item()
                {
                    ProductId = productId,
                    CartId = cartId,
                    Title = productTitle,
                    Image = imageURL,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    CustomerId = custId
                };
                cart.Items.Add(item);
                cart.CustomerId = custId;
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
        return cart;
    }

    public async Task<int> GetCartId(int custId)
    {
        int cartId = 0;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "select id from carts where custid =@custId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@custId", custId);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                cartId = int.Parse(reader["id"].ToString());
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
        return (int)cartId;
    }

    public async Task<List<Item>> GetCartDetails(int custId)
    {
        List<Item> items = new List<Item>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "select cartitems.id,cartitems.cartid,products.title,products.image,products.unitprice,cartitems.productid,cartitems.quantity from carts inner join cartitems on carts.id =cartitems.cartid inner join products on products.id=cartitems.productid where custid=@custId";

            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@custId", custId);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int cartItemId = int.Parse(reader["id"].ToString());
                int productId = int.Parse(reader["productid"].ToString());
                int cartId = int.Parse(reader["cartid"].ToString());
                string productTitle = reader["title"].ToString();
                string imageURL = reader["image"].ToString();
                int quantity = int.Parse(reader["quantity"].ToString());
                double unitPrice = double.Parse(reader["unitprice"].ToString());

                Item item = new Item()
                {
                    CartItemId = cartItemId,
                    ProductId = productId,
                    CartId = cartId,
                    Title = productTitle,
                    Image = imageURL,
                    Quantity = quantity,
                    UnitPrice = unitPrice
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
    public async Task<bool> RemoveItem(int cartItemId)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "Delete from cartitems where id = @cartItemId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@cartItemId", cartItemId);
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


    public async Task<bool> Update(Item item)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "update cartitems set quantity =@quantity , productid=@productId , cartid=@cartId  where id=@id";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            command.Parameters.AddWithValue("@productId", item.ProductId);
            command.Parameters.AddWithValue("@quantity", item.Quantity);
            command.Parameters.AddWithValue("@cartId", item.CartId);
            command.Parameters.AddWithValue("@id", item.CartItemId);
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




    public async Task<Item> Get(int id)
    {
        Item item = new Item();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "select * FROM cartitems where id =@id;";

            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int productId = int.Parse(reader["productid"].ToString());
                int cartId = int.Parse(reader["cartid"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());


                item = new Item()
                {
                    ProductId = productId,
                    CartId = cartId,
                    Quantity = quantity,
                    CartItemId = id
                };

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
        return item;
    }
    public async Task<bool> CreateOrder(int CartId)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            MySqlCommand command = new MySqlCommand("CreateOrder", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cartId", CartId);
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

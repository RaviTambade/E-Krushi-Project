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
            string query = "SELECT products.title,products.image,products.unitprice,cartitems.quantity,cartitems.productid,cartitems.cartid FROM products inner join cartitems on products.id=cartitems.productid where cartitems.cartid=@cartId";
            
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
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
                    CartId=cartId,
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



    public async Task<bool> AddItem(Item item)
    {
        bool status = false;
        Console.WriteLine(item.CartId);
        Console.WriteLine(item.ProductId);
        Console.WriteLine(item.Quantity);
        MySqlConnection con = new MySqlConnection();
        try
        {
            con.ConnectionString = _conString;
            await con.OpenAsync();
            string query = "INSERT into cartitems(cartid,productid,quantity) VALUES ((select id from carts where custid=@custId),@productId,@quantity)";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@custId",item.CustomerId);
            command.Parameters.AddWithValue("@productId", item.ProductId);
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

    public async Task<List<Cart>> GetAll(int custId)
    {
        Cart cart = new Cart();
        List<Item> cartItems = new List<Item>();
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT cartitems.cartid, products.title,products.image,products.unitprice,cartitems.quantity,cartitems.productid,carts.custid FROM products inner join " + 
                           "cartitems on products.id=cartitems.productid inner join carts on carts.id=cartitems.cartid where carts.custid=@custId";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@custId", custId);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
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
                    CartId=cartId,
                    Title = productTitle,
                    Image = imageURL,
                    Quantity = quantity,
                    UnitPrice = unitPrice
                };
                cartItems.Add(item);
                cart.CustomerId = custId;
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
        return cartItems;
    }
}
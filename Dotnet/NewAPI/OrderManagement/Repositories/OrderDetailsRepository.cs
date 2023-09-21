using Transflower.EKrushi.OrderManagement.Models;
using MySql.Data.MySqlClient;
using Transflower.EKrushi.OrderManagement.Repositories.Interfaces;

namespace Transflower.EKrushi.OrderManagement.Repositories;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public OrderDetailsRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }

 



    public async Task<List<OrderDetails>> GetDetails(int orderId)
    {
        List<OrderDetails> orders = new List<OrderDetails>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select productdetails.size,productdetails.unitprice,products.image,products.title,orderdetails.quantity,(productdetails.unitprice * orderdetails.quantity) as total from products Inner JOIN productdetails on products.id=productdetails.productid INNER join  orderdetails on productdetails.id=orderdetails.productdetailsid INNER join orders on  orders.id=orderdetails.orderid where orders.id=@orderId";           
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId",orderId);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {               
                double total = double.Parse(reader["total"].ToString());
                string? image = reader["image"].ToString();
                string? size = reader["size"].ToString();
                string? title = reader["title"].ToString();
                int unitPrice = int.Parse(reader["unitprice"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());
                
                
                OrderDetails orderDetails = new OrderDetails()
                {
                    Total = total,
                    Image = image,
                    Size = size,
                    Title = title,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                  
                };
                orders.Add(orderDetails);
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
        return orders;
    }
}
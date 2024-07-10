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

    public async Task<List<OrderDetails>> GetAllOrderDetails()
    {
        List<OrderDetails> orderDetails = new List<OrderDetails>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT * FROM orderdetails";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                int orderId = int.Parse(reader["orderid"].ToString());
                int productId = int.Parse(reader["productid"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());
                double discount = double.Parse(reader["discount"].ToString());

                OrderDetails orderDetail = new OrderDetails()
                {
                    Id = id,
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                    Discount = discount
                };
                orderDetails.Add(orderDetail);
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
        return orderDetails;
    }

    public async Task<OrderDetails> GetOrderDetail(int id)
    {
        OrderDetails orderDetail = new OrderDetails();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT * FROM orderdetails where id=@orderDetailsId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderDetailsId",id);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                //int id = Int32.Parse(reader["orderdetails_id"].ToString());
                int orderId = Int32.Parse(reader["orderid"].ToString());
                int productId = Int32.Parse(reader["productid"].ToString());
                int quantity = Int32.Parse(reader["quantity"].ToString());
                double discount = double.Parse(reader["discount"].ToString());

                orderDetail = new OrderDetails()
                {
                    Id = id,
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                    Discount = discount
                };
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
        return orderDetail;
    }
    public async Task<bool> Insert(OrderDetails orderDetail)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "INSERT INTO orderdetails(orderid,productid,quantity,discount) VALUES(@orderId,@productId,@quantity,@discount)";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId",orderDetail.OrderId);
            command.Parameters.AddWithValue("@productId",orderDetail.ProductId);
            command.Parameters.AddWithValue("@quantity",orderDetail.Quantity);
            command.Parameters.AddWithValue("@discount",orderDetail.Discount);
            int rowsAffected =command.ExecuteNonQuery();
            if(rowsAffected > 0){
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

    public async Task<bool> Update(OrderDetails orderDetail)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "Update orderdetails set orderid=@orderId, productid=@productId,quantity=@quantity, discount=@discount Where id =@orderDetailsId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderDetailsId",orderDetail.Id);
            command.Parameters.AddWithValue("@orderId",orderDetail.OrderId);
            command.Parameters.AddWithValue("@productId",orderDetail.ProductId);
            command.Parameters.AddWithValue("@quantity",orderDetail.Quantity);
            command.Parameters.AddWithValue("@discount",orderDetail.Discount);
            int rowsAffected =command.ExecuteNonQuery();
            if(rowsAffected > 0){
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
    public async Task<bool> Delete(int id)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "DELETE FROM orderDetails where id =@orderDetailsId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderDetailsId",id);
            int rowsAffected =command.ExecuteNonQuery();
            if(rowsAffected > 0){
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

    public async Task<List<OrderHistory>> GetDetails(int orderId)
    {
        List<OrderHistory> orders = new List<OrderHistory>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select orders.id,customers.firstname,customers.lastname, products.title,products.unitprice,orders.custid,(products.unitprice*cartitems.quantity)as total,orders.status ,cartitems.quantity from customers,orderdetails,orders,cartitems inner join products on products.id = cartitems.productid where orders.id = orderdetails.orderid and orderdetails.productid =cartitems.productid and customers.id=orders.custid and orders.id=@orderId";           
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId",orderId);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {               
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();
                string? title = reader["title"].ToString();
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();
                int unitPrice = int.Parse(reader["unitprice"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());
                 int custid = int.Parse(reader["custid"].ToString());
                
                OrderHistory orderHistory = new OrderHistory()
                {
                    Total = total,
                    Status = status,
                    Title = title,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                  
                };
                orders.Add(orderHistory);
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
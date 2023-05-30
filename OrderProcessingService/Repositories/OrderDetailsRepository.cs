using OrderProcessingService.Models;
using MySql.Data.MySqlClient;
using OrderProcessingService.Repositories.Interfaces;

namespace OrderProcessingService.Repositories;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _conString;

    public OrderDetailsRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<OrderDetails>> GetAllOrderDetails()
    {
        List<OrderDetails> orderDetails = new List<OrderDetails>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orderdetails";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
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
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return orderDetails;
    }

    public async Task<OrderDetails> GetOrderDetail(int id)
    {
        OrderDetails orderDetail = new OrderDetails();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orderdetails where id=@orderDetailsId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
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
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return orderDetail;
    }
    public async Task<bool> Insert(OrderDetails orderDetail)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "INSERT INTO orderdetails(orderid,productid,quantity,discount) VALUES(@orderId,@productId,@quantity,@discount)";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId",orderDetail.OrderId);
            command.Parameters.AddWithValue("@productId",orderDetail.ProductId);
            command.Parameters.AddWithValue("@quantity",orderDetail.Quantity);
            command.Parameters.AddWithValue("@discount",orderDetail.Discount);
            int rowsAffected =command.ExecuteNonQuery();
            if(rowsAffected > 0){
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

    public async Task<bool> Update(OrderDetails orderDetail)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "Update orderdetails set orderid=@orderId, productid=@productId,quantity=@quantity, discount=@discount Where id =@orderDetailsId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
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
    public async Task<bool> Delete(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM orderDetails where id =@orderDetailsId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDetailsId",id);
            int rowsAffected =command.ExecuteNonQuery();
            if(rowsAffected > 0){
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
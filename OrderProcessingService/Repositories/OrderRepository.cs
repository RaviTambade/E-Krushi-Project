using OrderProcessingService.Models;
using OrderProcessingService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace OrderProcessingService.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _conString;

    public OrderRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<List<Order>> Orders()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orders";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["orderdate"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shippeddate"].ToString());
                int customerId = int.Parse(reader["custid"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                Order order = new Order()
                {
                    Id = id,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
                    CustomerId = customerId,
                    Total = total,
                    Status = status
                };

                orders.Add(order);
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
        return orders;
    }

    public async Task<Order> GetOrder(int id)
    {
        Order order = new Order();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orders where id=@orderId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId",id);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                //int orderId = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["orderdate"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shippeddate"].ToString());
                int customerId = int.Parse(reader["custid"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                order = new Order()
                {
                    Id = id,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
                    CustomerId = customerId,
                    Total = total,
                    Status = status
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
        return order;
    }

    

   
    public async Task<List<Order>> OrderByCustId(int id)
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orders where custid=@customerId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@customerId",id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int orderId = int.Parse(reader["id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["orderdate"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shippeddate"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                Order order = new Order()
                {
                    Id = orderId,
                    CustomerId = id,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
                    Total = total,
                    Status = status
                };
                orders.Add(order);
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
        return orders;
    }
    public async Task<bool> Insert(Order order)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "INSERT INTO orders(orderdate,shippeddate,custid,total,status)VALUES(@orderDate,@shippedDate,@customerId,@total,@status)";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDate",order.OrderDate);
            command.Parameters.AddWithValue("@shippedDate",order.ShippedDate);
            command.Parameters.AddWithValue("@customerId",order.CustomerId);
            command.Parameters.AddWithValue("@total",order.Total);
            command.Parameters.AddWithValue("@status",order.Status);
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

    public async Task<bool> Update(Order order)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "Update orders set orderdate=@orderDate, shippeddate=@shippedDate,custid=@customerId, total =@total, status =@status Where id =@orderId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId",order.Id);
            command.Parameters.AddWithValue("@orderDate",order.OrderDate);
            command.Parameters.AddWithValue("@shippedDate",order.ShippedDate);
            command.Parameters.AddWithValue("@customerId",order.CustomerId);
            command.Parameters.AddWithValue("@total",order.Total);
            command.Parameters.AddWithValue("@status",order.Status);
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
            string query = "DELETE FROM orders where id =@orderId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId",id);
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

    public async Task<List<Order>> Cancelled()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orders WHERE custid=1 and status='cancelled' ";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while ( await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["orderdate"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shippeddate"].ToString());
                int customerId = int.Parse(reader["custid"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                Order order = new Order()
                {
                    Id = id,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
                    CustomerId = customerId,
                    Total = total,
                    Status = status
                };

                orders.Add(order);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return orders;
    }


    public async Task<List<Order>> Delivered()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {

            string query = " SELECT * FROM orders WHERE custid=1 and status='delivered' ";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["orderdate"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shippeddate"].ToString());
                int customerId = int.Parse(reader["custid"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                Order order = new Order()
                {
                    Id = id,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
                    CustomerId = customerId,
                    Total = total,
                    Status = status
                };

                orders.Add(order);
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
        return orders;
    }

    public async Task<int> GetCountByDate(DateTime date)
    {

        Int64 count=0;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT count(*) FROM orders where orderdate < @date";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@date",date);
            count = (Int64)command.ExecuteScalar();   
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return (int)count;
    }
    public async Task<int> TotalCount()
    {
        Int64 count=0;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT count(*) FROM orders";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            count = (Int64)command.ExecuteScalar();   
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return (int)count;
    }
}
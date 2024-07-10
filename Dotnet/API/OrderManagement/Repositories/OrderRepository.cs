using Transflower.EKrushi.OrderManagement.Models;
using Transflower.EKrushi.OrderManagement.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Transflower.EKrushi.OrderManagement.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<List<Order>> Orders()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT * FROM orders";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
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
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return orders;
    }

    public async Task<Order> GetOrder(int id)
    {
        Order order = new Order();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT * FROM orders where id=@orderId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId", id);
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
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return order;
    }




    public async Task<List<Order>> OrderByCustId(int id)
    {
        List<Order> orders = new List<Order>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT * FROM orders where custid=@customerId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", id);
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
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return orders;
    }
    public async Task<bool> Insert(Order order)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "INSERT INTO orders(orderdate,shippeddate,custid,total,status)VALUES(@orderDate,@shippedDate,@customerId,@total,@status)";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderDate", order.OrderDate);
            command.Parameters.AddWithValue("@shippedDate", order.ShippedDate);
            command.Parameters.AddWithValue("@customerId", order.CustomerId);
            command.Parameters.AddWithValue("@total", order.Total);
            command.Parameters.AddWithValue("@status", order.Status);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }

    public async Task<bool> Update(Order order)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "Update orders set orderdate=@orderDate, shippeddate=@shippedDate,custid=@customerId, total =@total, status =@status Where id =@orderId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId", order.Id);
            command.Parameters.AddWithValue("@orderDate", order.OrderDate);
            command.Parameters.AddWithValue("@shippedDate", order.ShippedDate);
            command.Parameters.AddWithValue("@customerId", order.CustomerId);
            command.Parameters.AddWithValue("@total", order.Total);
            command.Parameters.AddWithValue("@status", order.Status);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception )
        {
            throw ;
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
            string query = "DELETE FROM orders where id =@orderId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId", id);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }

    public async Task<List<Order>> Cancelled()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT * FROM orders WHERE custid=1 and status='cancelled' ";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
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
            reader.Close();
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return orders;
    }


    public async Task<List<Order>> Delivered()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try{

            string query = " SELECT * FROM orders WHERE custid=1 and status='delivered' ";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
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
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return orders;
    }

    public async Task<int> GetCountByDate(DateTime date)
    {

        Int64 count = 0;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT count(*) FROM orders where orderdate < @date";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@date", date);
            count = (Int64)command.ExecuteScalar();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return (int)count;
    }
    public async Task<int> TotalCount()
    {
        Int64 count = 0;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT count(*) FROM orders";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            count = (Int64)command.ExecuteScalar();
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return (int)count;
    }

    public async Task<List<OrderHistory>> GetOrderHistory(int custId)
    {
        List<OrderHistory> orders = new List<OrderHistory>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select orders.id,customers.firstname,customers.lastname,orders.orderdate,orders.shippeddate, products.title,products.unitprice,(products.unitprice*cartitems.quantity)as total,orders.status ,products.image,cartitems.quantity from customers,orderdetails,orders,cartitems inner join products on products.id = cartitems.productid where orders.id = orderdetails.orderid and orderdetails.productid =cartitems.productid and customers.id=orders.custid and orders.custid=@custId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@custId", custId);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int orderId = int.Parse(reader["id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["orderdate"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shippeddate"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();
                string? title = reader["title"].ToString();
                string? image = reader["image"].ToString();
                int unitPrice = int.Parse(reader["unitprice"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();
                OrderHistory orderHistory = new OrderHistory()
                {
                    OrderId = orderId,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
                    Total = total,
                    Status = status,
                    Title = title,
                    Image = image,
                    UnitPrice = unitPrice,
                    Quantity = quantity


                };
                orders.Add(orderHistory);
            }
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return orders;
    }

    public async Task<List<CustomerOrder>> GetOrderDetails()
    {
        List<CustomerOrder> customerOrders = new List<CustomerOrder>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = " SELECT orders.id,customers.firstname,customers.lastname,orders.orderdate from orders inner join customers on customers.id=orders.custid";

            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["orderdate"].ToString());
                string firstName = reader["firstname"].ToString();
                string lastName = reader["lastname"].ToString();

                CustomerOrder customerOrder = new CustomerOrder()
                {
                    Id = id,
                    OrderDate = orderDate,
                    FirstName = firstName,
                    LastName = lastName

                };

                customerOrders.Add(customerOrder);
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
        return customerOrders;
    }

    public async Task<List<Order>> FilterDate(DateTime fromDate, DateTime toDate)
    {
        List<Order> orders = new List<Order>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT * FROM orders WHERE orderdate BETWEEN @fromDate AND @toDate";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@fromDate", fromDate);
            command.Parameters.AddWithValue("@toDate", toDate);
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
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


    public async Task<List<CustomerOrder>> GetOrderDetails(int customerid)
    {
        List<CustomerOrder> customerOrders = new List<CustomerOrder>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select id as orderid,status,orderdate,total from orders where customerid=@customerid";

            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerid",customerid);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["orderid"].ToString());
                DateTime orderDate = DateTime.Parse(reader["orderdate"].ToString());
                string status = reader["status"].ToString();
                string total = reader["total"].ToString();

                CustomerOrder customerOrder = new CustomerOrder()
                {
                    Id = id,
                    OrderDate = orderDate,
                    Status = status,
                    Total = total
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

   





}
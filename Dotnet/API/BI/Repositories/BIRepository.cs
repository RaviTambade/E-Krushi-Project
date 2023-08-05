using BIService.Models;
using BIService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace BIService.Repositories;
public class BIRepository : IBIRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _conString;

    public BIRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<OrderChart>> GetCountByMonth(int year )
    {

       List<OrderChart> orders = new List<OrderChart>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT MONTHNAME(orderdate) AS monthname, COUNT(*) AS count FROM orders WHERE YEAR(orderdate) = @year GROUP BY MONTHNAME(orderdate), MONTH(orderdate) ORDER BY MONTH(orderdate) ASC;";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@year",year);
            MySqlDataReader reader = command.ExecuteReader();   
            while (await reader.ReadAsync())
            {
                int count = int.Parse(reader["count"].ToString()); 
                string? monthName = reader["monthname"].ToString();

                OrderChart order = new OrderChart()
                {
                    Count = count,
                    MonthName = monthName   
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

    public async Task<List<OrderChart>> OrderStatus(int year )
    {

       List<OrderChart> orders = new List<OrderChart>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select status,sum(status) as total from orders where year(orderdate)=@year group by status;";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@year",year);
            MySqlDataReader reader = command.ExecuteReader();   
            while (await reader.ReadAsync())
            {
                string status = reader["status"].ToString(); 
                int total = int.Parse(reader["total"].ToString());

                OrderChart order = new OrderChart()
                {
                    Status = status,
                    Total = total   
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
}
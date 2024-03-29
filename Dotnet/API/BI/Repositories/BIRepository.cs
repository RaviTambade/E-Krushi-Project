using System.Data;
using Transflower.EKrushi.BIService.Models;
using Transflower.EKrushi.BIService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Transflower.EKrushi.BIService.Repositories;
public class BIRepository : IBIRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public BIRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<OrderChart>> GetCountByMonth(int year )
    {

       List<OrderChart> orders = new List<OrderChart>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT MONTHNAME(orderdate) AS monthname, COUNT(*) AS count FROM orders WHERE YEAR(orderdate) = @year GROUP BY MONTHNAME(orderdate), MONTH(orderdate) ORDER BY MONTH(orderdate) ASC;";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
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

    public async Task<List<OrderChart>> OrderStatus(int year )
    {

       List<OrderChart> orders = new List<OrderChart>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select status,sum(status) as total from orders where year(orderdate)=@year group by status;";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
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

    public async Task<List<ProductSale>> GetProductReport(int year)
       {

        List<ProductSale> questions = new List<ProductSale>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select title,productid,sum(quantity) as quantity from products inner join orderdetails on products.id=orderdetails.productid  inner join orders on orders.id=orderdetails.orderid where year(shippeddate)=@year group by productid";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@year",year);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                string title = reader["title"].ToString();
                int quantity = int.Parse(reader["quantity"].ToString());
                

                ProductSale question = new ProductSale()
                {
                    Title =title,
                    Quantity = quantity,  
                };
                questions.Add(question);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questions;
    }
    public async Task<List<CustomerReport>> GetCustomerReport(int custId)
        {
            List<CustomerReport> customers = new List<CustomerReport>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try{
                string query = "select title,productid,sum(quantity) as total from products inner join orderdetails on products.id=orderdetails.productid inner join orders on orders.id = orderdetails.orderid where custid =@custId group by productid";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.Parameters.AddWithValue("@custId", custId);
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while(await reader.ReadAsync())
                {
                    int totalQuantity = int.Parse(reader["total"].ToString());
                    string title = reader["title"].ToString();
                    
                
                CustomerReport customer = new CustomerReport()
                {
                    TotalQuantity=totalQuantity,
                    Title=title
                };
                customers.Add(customer);
                }
                await reader.CloseAsync();
            }
        catch(Exception ){
            throw ;
        }
        finally{
            await connection.CloseAsync();
        }
        return customers;
    }
    public async Task<List<SMEReport>> GetSMEReport(int year)
    {

        List<SMEReport> questions = new List<SMEReport>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;

        try
        {

            string query = "SELECT name,smeid,count(*) as count FROM SMEANSWERS inner join subjectmatterexperts on SMEANSWERS.smeid=subjectmatterexperts.id WHERE YEAR(answerdate) = @year group by smeid";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@year",year);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                string name = reader["name"].ToString();
                int count = int.Parse(reader["count"].ToString());
                

                SMEReport question = new SMEReport()
                {
                    Name =name,
                    Count = count,  
                };
                questions.Add(question);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questions;
    } 

    public async Task<List<OrderChart>> GetTotalRevenue(int year)
    {

        List<OrderChart> questions = new List<OrderChart>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT MONTHNAME(orderdate) AS monthname,sum(total) as total from orders where year(orderdate)=@year group by MONTHNAME(orderdate), MONTH(orderdate) ORDER BY MONTH(orderdate) ASC";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@year",year);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                string monthName = reader["monthname"].ToString();
                int total = int.Parse(reader["total"].ToString());
                

                OrderChart question = new OrderChart()
                {
                    MonthName =monthName,
                    Total = total,  
                };
                questions.Add(question);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questions;
    } 

    public async Task<List<OrderChart>> GetWeeklyOrders(int year)
    {

        List<OrderChart> orders = new List<OrderChart>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT WEEK(orderdate, 1) AS WeekNumber, count(*) AS total FROM orders WHERE  YEAR(orderdate) = @year GROUP BY WEEK(orderdate, 1) ORDER BY WEEK(orderdate, 1)"; 
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@year",year);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                string weekNumber = reader["WeekNumber"].ToString();
                int total = int.Parse(reader["total"].ToString());
                

                OrderChart order = new OrderChart()
                {
                    WeekNumber =weekNumber,
                    Total = total,  
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

    public async Task<List<OrderChart>> GetYearlyOrders()
    {

        List<OrderChart> orders = new List<OrderChart>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT  year(orderdate) AS year, count(*) AS total FROM orders GROUP BY  year(orderdate) ORDER BY year(orderdate) ASC ";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int year = int.Parse(reader["year"].ToString());
                int total = int.Parse(reader["total"].ToString());
                

                OrderChart order = new OrderChart()
                {
                    Year =year,
                    Total = total,  
                };
                orders.Add(order);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return orders;
    } 

    public async Task<List<OrderChart>> GetYearlySMEPerformance
    ()
    {

        List<OrderChart> orders = new List<OrderChart>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select year(orders.shippeddate) as year, status,sum(status) as total  from orders group by year(orders.shippeddate) ,status ";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int year = int.Parse(reader["year"].ToString());
                int total = int.Parse(reader["total"].ToString());
                string status =reader["status"].ToString();
                

                OrderChart order = new OrderChart()
                {
                    Year =year,
                    Total = total,  
                    Status = status
                };
                orders.Add(order);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return orders;
    }

}
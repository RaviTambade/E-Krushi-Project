using System.Data;
using Transflower.EKrushi.BIService.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using Transflower.EKrushi.BIService.Models;

namespace Transflower.EKrushi.BIService.Repositories;

public class BIRepository : IBIRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public BIRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString =
            _configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentException("ConnectionString is null");
    }

    public async Task<OrderCount> OrdersCountByStore(DateTime todaysDate, int storeId)
    {
        OrderCount orders = new OrderCount();
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            MySqlCommand cmd = new MySqlCommand("GetStoreOrderCountForMonth", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@given_date", todaysDate);
            cmd.Parameters.AddWithValue("@givenStoreId", storeId);
            cmd.Parameters.AddWithValue("@todaysOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@yesterdaysOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@weekOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@monthOrders", MySqlDbType.Int32);

            cmd.Parameters["@todaysOrders"].Direction = ParameterDirection.Output;
            cmd.Parameters["@yesterdaysOrders"].Direction = ParameterDirection.Output;
            cmd.Parameters["@weekOrders"].Direction = ParameterDirection.Output;
            cmd.Parameters["@monthOrders"].Direction = ParameterDirection.Output;
            await connection.OpenAsync();
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            orders.TodaysOrders = (int)cmd.Parameters["@todaysOrders"].Value;
            orders.YesterdaysOrders = (int)cmd.Parameters["@yesterdaysOrders"].Value;
            orders.WeekOrders = (int)cmd.Parameters["@weekOrders"].Value;
            orders.MonthOrders = (int)cmd.Parameters["@monthOrders"].Value;
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

    public async Task<List<TopProducts>> GetTopFiveSellingProducts(DateTime todaysDate, string mode,int storeId)
    {
        List<TopProducts> products = new List<TopProducts>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            MySqlCommand cmd = new MySqlCommand("GetTopFiveSellingProductQuantityByStore", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@todays_date", todaysDate);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@store_id", storeId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                TopProducts product = new TopProducts()
                {
                    ProductId = reader.GetInt32("productid"),
                    Quantity = reader.GetInt32("quantity"),
                    TotalQuantity=reader.GetInt32("totalquantity"),
                    Title = reader.GetString("title"),
                    Percentage=reader.GetDouble("percentage"),
                    ImageURL=reader.GetString("imageurl"),
                };
                products.Add(product);
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
        return products;
    }



    public async Task<List<MonthOrders>> GetMonthOrders(int year, int storeId)
    {
        List<MonthOrders> products = new List<MonthOrders>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            MySqlCommand cmd = new MySqlCommand("GetStoreOrderCountByMonth", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@given_year",year);
            cmd.Parameters.AddWithValue("@given_storeid", storeId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                MonthOrders product = new MonthOrders()
                {
                    Month = reader.GetString("month"),
                    OrderCount = reader.GetInt32("order_count"),
                  
                };
                products.Add(product);
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
        
        return products;    
    }



    public async Task<List<CategorywiseProduct>> GetCategorywiseProductsCount(DateTime todaysDate, string mode,int storeId)
    {
        List<CategorywiseProduct> products = new List<CategorywiseProduct>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            MySqlCommand cmd = new MySqlCommand("GetCategorywiseProductCountByStore", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@given_date", todaysDate);
            cmd.Parameters.AddWithValue("@mode", mode);
            cmd.Parameters.AddWithValue("@store_id", storeId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                CategorywiseProduct product = new CategorywiseProduct()
                {
                    Title= reader.GetString("title"),
                    Quantity = reader.GetInt32("quantity"),
                    
                };
                products.Add(product);
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
        return products;
    }

 public async Task<List<DeliveredOrders>> GetDeliveredOrdersbyMonth(int year, int shipperId)
    {
        List<DeliveredOrders> orders = new List<DeliveredOrders>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            MySqlCommand cmd = new MySqlCommand("deliverorderscountbymonth", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@given_year",year);
            cmd.Parameters.AddWithValue("@given_shipperid", shipperId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                DeliveredOrders order = new DeliveredOrders()
                {
                    Month = reader.GetString("month"),
                    OrdersCount = reader.GetInt32("count"),
                  
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

    


    public async Task<List<NotAnsweredQuestions>> GetNotAnsweredQuestions(int userId)
    {
        List<NotAnsweredQuestions> questions = new List<NotAnsweredQuestions>();
        MySqlConnection connection = new MySqlConnection(_connectionString);

        try
        {
            MySqlCommand cmd = new MySqlCommand("NotAnsweredQuestions", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@given_userid",userId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                NotAnsweredQuestions question = new NotAnsweredQuestions()
                {
                    QuestionId = reader.GetInt32("id"),
                    Question = reader.GetString("description"),
                  
                };
                questions.Add(question);
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
        
        return questions;    
    }

}

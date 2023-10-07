using System.Data;
using System.Text;
using System.Text.Json;
using Dapper;
using MySql.Data.MySqlClient;
using Stores.Models;
using Stores.Repositories.Interfaces;

namespace Stores.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    private readonly IHttpClientFactory _httpClientFactory;

    public StoreRepository(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;

        _connectionString =
            this._configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException("connection Sting Not Found");
    }

    public async Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<StoreOrder>(
                "SELECT id, orderdate, shippeddate,total, status FROM orders where storeid=@storeId",
                new { storeId = storeId }
            );
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    public async Task<int> GetNearestStoreId(int customerAddressId)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            int addressId = await GetNearestStoreAddressId(customerAddressId);

            if (addressId == default)
            {
                return default;
            }

            var query = "SELECT Id FROM Stores WHERE addressid = @AddressId";
            connection.Open();

            var storeId = await connection.ExecuteScalarAsync<int>(
                query,
                new { AddressId = addressId }
            );

            return storeId;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    public async Task<int> GetStoreUserId(int  storeId)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {

            var query = "SELECT userid FROM stores WHERE id = @StoreId";
            connection.Open();

            var userId = await connection.ExecuteScalarAsync<int>(
                query,
                new { StoreId = storeId }
            );

            return userId;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }



    private async Task<int> GetNearestStoreAddressId(int customerAddressId)
    {
        try
        {
            string addressIdsAsString = await GetAddressIdOfStores();
            var body = new
            {
                addressId = customerAddressId,
                storeAddressIdString = addressIdsAsString
            };
            string jsonBody = JsonSerializer.Serialize(body);
            var requestContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            string requestUrl = "http://localhost:5102/api/addresses/nearest";

            HttpClient httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsync(requestUrl, requestContent);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                int addressId = JsonSerializer.Deserialize<int>(apiResponse);
                return addressId;
            }
        }
        catch (Exception)
        {
            throw;
        }
        return default;
    }

    private async Task<string> GetAddressIdOfStores()
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            return await connection.QueryFirstAsync<string>(
                @"SELECT GROUP_CONCAT(addressid) AS ConcatenatedAddressIds FROM Stores"
            );
        }
        catch (Exception)
        {
            throw;
        }
    }


  public OrderSp OrdersStoredProcedure(DateTime todaysDate,int storeId)

    {
        OrderSp  orders= new OrderSp();
        

        MySqlConnection con = new MySqlConnection(_connectionString);

        //Create Command Object

        try{

            con.Open();

            MySqlCommand cmd = new MySqlCommand("GetOrdersByDate", con as MySqlConnection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@given_date",todaysDate);
             cmd.Parameters.AddWithValue("@givenStoreId",storeId);

            

            cmd.Parameters.AddWithValue("@todaysOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@yesterdaysOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@weekOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@monthOrders", MySqlDbType.Int32);

            cmd.Parameters["@todaysOrders"].Direction=ParameterDirection.Output;
            cmd.Parameters["@yesterdaysOrders"].Direction=ParameterDirection.Output;
            cmd.Parameters["@weekOrders"].Direction=ParameterDirection.Output;
            cmd.Parameters["@monthOrders"].Direction=ParameterDirection.Output;

            int rowsAffected = cmd.ExecuteNonQuery();
            

             orders.TodaysOrders =(int)cmd.Parameters["@todaysOrders"].Value;
             orders.YesterdaysOrders =(int)cmd.Parameters["@yesterdaysOrders"].Value;
             orders.WeekOrders =(int)cmd.Parameters["@weekOrders"].Value;
             orders.MonthOrders =(int)cmd.Parameters["@monthOrders"].Value;

           
        }

        catch (Exception e)

        {

            throw e;

        }

        finally

        {

            con.Close();

        }

        return orders;

    }


}

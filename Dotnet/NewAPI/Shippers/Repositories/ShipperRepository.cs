using System.Text;
using System.Text.Json;
using Dapper;
using MySql.Data.MySqlClient;
using TransFlower.EKrushi.Shippers.Models;
using TransFlower.EKrushi.Shippers.Repositories.Interfaces;

namespace TransFlower.EKrushi.Shippers.Repositories;

public class ShipperRepository : IShipperRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    private readonly IHttpClientFactory _httpClientFactory;

    public ShipperRepository(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;

        _connectionString =
            this._configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException("connection Sting Not Found");
    }

    public async Task<int> GetNearestShipperId(int storeId)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            int addressId = await GetNearestShipperAddressId(storeId);

            if (addressId == default)
            {
                return default;
            }

            var query = "SELECT id FROM shippers WHERE addressid = @AddressId";
            connection.Open();

            var shipperId = await connection.ExecuteScalarAsync<int>(
                query,
                new { AddressId = addressId }
            );

            return shipperId;
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

    private async Task<int> GetNearestShipperAddressId(int storeId)
    {
        try
        {
            int storeAddressId = await GetAddressIdOfStore(storeId);
            var shipperaddressIdString = await GetAddressIdOfShippers();
            var body = new { addressId = storeAddressId, addressIdString = shipperaddressIdString };
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

    private async Task<string> GetAddressIdOfShippers()
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            return await connection.QueryFirstAsync<string>(
                @"SELECT GROUP_CONCAT(addressid) AS ConcatenatedAddressIds FROM 
                shippers"
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

    private async Task<int> GetAddressIdOfStore(int storeId)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            return await connection.QueryFirstAsync<int>(
                @"SELECT addressid  FROM stores WHERE id=@StoreId",
                new { StoreId = storeId }
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

    public async Task<IEnumerable<ShipperOrder>> GetShipperOrdersByStatus(
        int shipperId,
        string status
    )
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<ShipperOrder>(
                @"SELECT orders.id as orderid,orders.orderdate,orders.shippeddate,
            stores.addressid as fromaddressId ,
            orders.addressid as toaddressid,orders.status from orders
            INNER JOIN stores on orders.storeid = stores.id
            INNER JOIN shipperorders on orders.id=shipperorders.orderid 
            WHERE orders.status=@Status AND shipperorders.shipperid=@ShipperId",
                new { ShipperId = shipperId, Status = status }
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

    public async Task<int> GetShipperIdByUserId(int userId)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            string query = "SELECT id FROM shippers WHERE userid = @UserId";
            connection.Open();

            int shipperId = await connection.ExecuteScalarAsync<int>(
                query,
                new { UserId = userId }
            );

            return shipperId;
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

    public async Task<OrderStatusCount> GetShipperOrdersCount(int shipperId)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            string query =
                @"SELECT
        SUM(CASE WHEN status = 'ready to dispatch' THEN 1 ELSE 0 END) AS readytodispatch,
        SUM(CASE WHEN status = 'picked' THEN 1 ELSE 0 END) AS picked,
        SUM(CASE WHEN status = 'in progress' THEN 1 ELSE 0 END) AS inprogress,
        SUM(CASE WHEN status = 'delivered' THEN 1 ELSE 0 END) AS delivered,
        SUM(CASE WHEN status = 'cancelled' THEN 1 ELSE 0 END) AS cancelled
        FROM orders   INNER JOIN shipperorders on orders.id=shipperorders.orderid 
        WHERE shipperorders.shipperid=@ShipperId";
            return await connection.QueryFirstAsync<OrderStatusCount>(
                query,
                new { ShipperId = shipperId }
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
}

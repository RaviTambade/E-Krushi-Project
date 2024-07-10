using MySql.Data.MySqlClient;
using Transflower.EKrushi.Suppliers.Repositories.Interfaces;

namespace Transflower.EKrushi.Suppliers.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public SupplierRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString =
            this._configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException("connection Sting Not Found");
    }

    public async Task<int> GetCorporateIdOfSupplier(int supplierId)
    {
        int corporateId = 0;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT suppliers.corporateid FROM suppliers
                WHERE suppliers.id=@id ";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", supplierId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                corporateId = reader.GetInt32("corporateid");
            }
            await reader.CloseAsync();
            return corporateId > 0 ? corporateId : throw new Exception($"Corporate Id for SupplierId {supplierId} not found");

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

    public async Task<int> GetSupplierId(int userId)
    {
        int supplierId = 0;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT suppliers.id FROM suppliers
                WHERE suppliers.userid=@userid ";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userid", userId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                supplierId = reader.GetInt32("id");
            }
            await reader.CloseAsync();
            return supplierId > 0 ? supplierId : throw new Exception($"Supplier Id for UserId {userId} not found");

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

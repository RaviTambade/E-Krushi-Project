using System.Data;
using MySql.Data.MySqlClient;
using Transflower.EKrushi.PaymentsAPI.Models;
using Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

namespace Transflower.EKrushi.PaymentsAPI.PaymentDetailsRepository;

public class PaymentRepository : IPaymentRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public PaymentRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString =
            this._configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(_connectionString);
    }

    public async Task<bool> AddPayment(PaymentAddModel payment)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_connectionString);
        try
        {
            await con.OpenAsync();
            MySqlCommand cmd = new MySqlCommand("insertpayment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mode", payment.Mode);
            cmd.Parameters.AddWithValue("@paymentstatus", payment.PaymentStatus);
            cmd.Parameters.AddWithValue("@orderid", payment.OrderId);
            cmd.Parameters.AddWithValue("@transactionId", payment.TransactionId);
            await cmd.ExecuteNonQueryAsync();
            status = true;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }

    public List<Payment> GetPayments(int customerid)
    {
        List<Payment> orders = new List<Payment>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                "select (date)as paymentdate,paymentstatus,orderid FROM payments where orderid in (SELECT id from orders where customerid=@customerId)";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", customerid);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = DateTime.Parse(reader["paymentdate"].ToString());
                int orderid = int.Parse(reader["orderid"].ToString());
                string paymentstatus = reader["paymentstatus"].ToString();

                Payment order = new Payment()
                {
                    PaymentDate = date,
                    OrderId = orderid,
                    PaymentStatus = paymentstatus
                };

                orders.Add(order);
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return orders;
    }
}

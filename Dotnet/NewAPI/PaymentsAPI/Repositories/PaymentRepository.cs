using System.Data;
using MySql.Data.MySqlClient;
using Transflower.EKrushi.PaymentsAPI.Models;
using Transflower.EKrushi.PaymentsAPI.Repositories.Interfaces;

namespace Transflower.EKrushi.PaymentsAPI.Repositories;

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

    public async Task<List<Payment>> GetPayments(int customerId)
    {
        List<Payment> payments = new List<Payment>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                "select (date)as paymentdate,paymentstatus,orderid FROM payments where orderid in (SELECT id from orders where customerid=@customerId)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", customerId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                DateTime date = reader.GetDateTime("paymentdate");
                int orderid = reader.GetInt32("orderid");
                string? paymentstatus = reader.GetString("paymentstatus");

                Payment payment = new Payment()
                {
                    PaymentDate = date,
                    OrderId = orderid,
                    PaymentStatus = paymentstatus
                };

                payments.Add(payment);
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
        return payments;
    }

    public async Task<PaymentDetail> GetPaymentDetails(int orderId)
    {
        PaymentDetail payment = new PaymentDetail();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query =
                "SELECT (payments.id) as paymentid ,  (orders.total) as total,(payments.date)as date,(payments.paymentstatus) as paymentstatus,(payments.mode)as mode from payments  INNER JOIN orders ON orders.id=payments.orderid where payments.orderid=@orderId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId", orderId);
            await connection.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                int paymentid = reader.GetInt32("paymentid");
                DateTime date = reader.GetDateTime("date");
                double total = reader.GetDouble("total");
                string paymentmode = reader.GetString("mode");
                string status = reader.GetString("paymentstatus");

                payment = new PaymentDetail()
                {
                    PaymentId = paymentid,
                    Date = date,
                    Total = total,
                    PaymentMode = paymentmode,
                    Status = status
                };
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
        return payment;
    }
}

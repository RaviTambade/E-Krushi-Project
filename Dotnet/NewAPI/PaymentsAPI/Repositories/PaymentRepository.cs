using MySql.Data.MySqlClient;
using Transflower.EKrushi.PaymentsAPI.InterFaces;
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
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }
   

    public List<Payment> GetPayments(int customerid)
    {
     List<Payment> orders = new List<Payment>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select (date)as paymentdate,paymentstatus,orderid FROM payments where orderid in (SELECT id from orders where customerid=@customerId)";
             connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", customerid);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                DateTime date = DateTime.Parse(reader["paymentdate"].ToString());
                int orderid = int.Parse(reader["orderid"].ToString());
                string paymentstatus =reader["paymentstatus"].ToString();
               
    

                Payment order = new Payment()
                {
                    PaymentDate = date,
                    OrderId=orderid,
                    PaymentStatus = paymentstatus
                
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
             connection.Close();
        }
        return orders;
    }
}
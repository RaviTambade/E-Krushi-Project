using MySql.Data.MySqlClient;
using Transflower.EKrushi.PaymentsAPI.InterFaces;
using Transflower.EKrushi.PaymentsAPI.Models;
using Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

namespace Transflower.EKrushi.PaymentsAPI.PaymentDetailsRepository;


public class PaymentDetailsRepository : IPaymentDetailsRepository

{

     private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public PaymentDetailsRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }
   

      public PaymentDetails GetPaymentDetails(int orderid)
    {
       PaymentDetails order = new PaymentDetails();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "SELECT date,paymentstatus,mode from payments where orderid=@orderId";
             connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@orderId", orderid);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                DateTime date = DateTime.Parse(reader["date"].ToString());
                string paymentmode =reader["mode"].ToString();
               
                string? status = reader["paymentstatus"].ToString();

                 order = new PaymentDetails()
                {
                    Date = date,
                    PaymentMode = paymentmode,
                    Status = status
                };
               
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
        return order;
    }
}
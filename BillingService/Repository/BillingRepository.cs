using E_krushiApp.BillingService.Interfaces;
using E_krushiApp.BillingService.Models;
using MySql.Data.MySqlClient;

namespace E_krushiApp.BillingService.Repositories;
public class BillingRepository : IBillingRepository
{

    private IConfiguration _configuration;
    private string _conString;
    public BillingRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

     public async Task<bool> AddBill(Billing bill)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Insert into billing(custid,productid,quantity,discount,date) VALUES(@custid,@productid,@quantity,@discount,@date)";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@custid",bill.Custid);
                cmd.Parameters.AddWithValue("@productid",bill.ProductId);
                cmd.Parameters.AddWithValue("@quantity",bill.Quantity);
                cmd.Parameters.AddWithValue("@discount",bill.Discount);
                cmd.Parameters.AddWithValue("@date",bill.Date);
               await con.OpenAsync();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return status;
        }
}
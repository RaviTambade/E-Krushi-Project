
using BankingService.Models;
using BankingService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace BankingService.Repositories{

public class AccountRepository : IAccountRepository
    {
    private IConfiguration _configuration;
    private string _conString;
    public AccountRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
        try{
            string query = "select * from accounts";
            MySqlCommand cmd = new MySqlCommand(query,con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int accountId = int.Parse(reader["account_id"].ToString());
                string accountNumber = reader["account_number"].ToString();
                string ifscCode = reader["ifsc_code"].ToString();
                DateTime registerDate = DateTime.Parse(reader["register_date"].ToString());
                int userId = int.Parse(reader["user_id"].ToString());
                Account account = new Account
                {
                    AccountId = accountId,
                    AccountNumber = accountNumber,
                    IFSCCode = ifscCode,
                    RegisterDate = registerDate,
                    UserId = userId
                };
                accounts.Add(account);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return accounts;
    }

        public Account GetAccount(int id)
        {
            Account account = new Account();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from accounts where account_id = @accountId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountId",id);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                //int accountId = int.Parse(reader["account_id"].ToString());
                string accountNumber = reader["account_number"].ToString();
                string ifscCode = reader["ifsc_code"].ToString();
                DateTime registerDate = DateTime.Parse(reader["register_date"].ToString());
                int userId = int.Parse(reader["user_id"].ToString());
                account = new Account
                {
                    AccountId = id,
                    AccountNumber = accountNumber,
                    IFSCCode = ifscCode,
                    RegisterDate = registerDate,
                    UserId = userId
                };
                reader.Close();
            }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return account;
        }

        public bool InsertAccount(Account account)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Insert into accounts(account_number,ifsc_code,register_date,user_id) VALUES(@accountNumber,@ifscCode,@registerDate,@userId)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountNumber",account.AccountNumber);
                cmd.Parameters.AddWithValue("@ifscCode",account.IFSCCode);
                cmd.Parameters.AddWithValue("@registerDate",account.RegisterDate);
                cmd.Parameters.AddWithValue("@userId",account.UserId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return status;
        }
        public bool UpdateAccount(Account account)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Update accounts set  account_number= @accountNumber, ifsc_code= @ifscCode, register_date = @registerDate, user_id=@userId where account_id = @accountId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountNumber",account.AccountNumber);
                cmd.Parameters.AddWithValue("@ifscCode",account.IFSCCode);
                cmd.Parameters.AddWithValue("@registerDate",account.RegisterDate);
                cmd.Parameters.AddWithValue("@userId",account.UserId);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return status;
        }
        public bool DeleteAccount(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Delete from accounts Where account_id = @accountId";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountId",id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return status;
        }
    }
}


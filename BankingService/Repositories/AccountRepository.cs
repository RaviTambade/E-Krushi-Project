
using BankingService.Repositories.Interfaces;
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

        public List<Account> Accounts()
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
                int accountId = int.Parse(reader["id"].ToString());
                string accountNumber = reader["number"].ToString();
                string ifscCode = reader["ifsccode"].ToString();
                DateTime registerDate = DateTime.Parse(reader["registerdate"].ToString());
                int userId = int.Parse(reader["userid"].ToString());
                Account account = new Account
                {
                    Id = accountId,
                    Number = accountNumber,
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
                string query = "select * from accounts where id = @accountId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountId",id);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                //int accountId = int.Parse(reader["account_id"].ToString());
                string accountNumber = reader["number"].ToString();
                string ifscCode = reader["ifsccode"].ToString();
                DateTime registerDate = DateTime.Parse(reader["registerdate"].ToString());
                int userId = int.Parse(reader["userid"].ToString());
                account = new Account
                {
                    Id = id,
                    Number = accountNumber,
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

        public bool Insert(Account account)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Insert into accounts(number,ifsccode,registerdate,userid) VALUES(@accountNumber,@ifscCode,@registerDate,@userId)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountNumber",account.Number);
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
        public bool Update(Account account)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Update accounts set number= @accountNumber, ifsccode= @ifscCode, registerdate = @registerDate, userid=@userId where id = @accountId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountNumber",account.Number);
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
        public bool Delete(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Delete from accounts Where id = @accountId";
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


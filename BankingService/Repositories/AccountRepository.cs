
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

        public async Task<List<Account>> Accounts()
        {
            List<Account> accounts = new List<Account>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
        try{
            string query = "select * from accounts";
            MySqlCommand cmd = new MySqlCommand(query,con);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(await reader.ReadAsync())
            {
                int accountId = int.Parse(reader["id"].ToString());
                string accountNumber = reader["acctnumber"].ToString();
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
            await reader.CloseAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return accounts;
    }

        public async Task<Account> GetAccount(int id)
        {
            Account account = new Account();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from accounts where id = @accountId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountId",id);
                await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(await reader.ReadAsync())
                {
                //int accountId = int.Parse(reader["account_id"].ToString());
                string accountNumber = reader["acctnumber"].ToString();
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
                await reader.CloseAsync();
            }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return account;
        }

        public async Task<bool> Insert(Account account)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Insert into accounts(acctnumber,ifsccode,registerdate,userid) VALUES(@accountNumber,@ifscCode,@registerDate,@userId)";
                await con.OpenAsync();
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
                await con.CloseAsync();
            }
            return status;
        }
        public async Task<bool> Update(Account account)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Update accounts set acctnumber= @accountNumber, ifsccode= @ifscCode, registerdate = @registerDate, userid=@userId where id = @accountId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@accountNumber",account.Number);
                cmd.Parameters.AddWithValue("@ifscCode",account.IFSCCode);
                cmd.Parameters.AddWithValue("@registerDate",account.RegisterDate);
                cmd.Parameters.AddWithValue("@userId",account.UserId);
                await con.OpenAsync();
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
                await con.CloseAsync();
            }
            return status;
        }
        public async Task<bool> Delete(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Delete from accounts Where id = @accountId";
                await con.OpenAsync();
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
                await con.CloseAsync();
            }
            return status;
        }
    }
}


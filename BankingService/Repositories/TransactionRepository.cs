
using BankingService.Repositories.Interfaces;
using BankingService.Models;
using BankingService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace BankingService.Repositories{

public class TransactionRepository : ITransactionRepository
    {
    private IConfiguration _configuration;
    private string _conString;
    public TransactionRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

        public async Task<List<Transaction>> Transactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
        try{
            string query = "select * from transactions";
            MySqlCommand cmd = new MySqlCommand(query,con);
             await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(await reader.ReadAsync())
            {
                int transactionId = int.Parse(reader["id"].ToString());
                string fromAccountNumber = reader["fromaccountnumber"].ToString();
                string toAccountNumber = reader["toaccountnumber"].ToString();
                DateTime transactionDate = DateTime.Parse(reader["date"].ToString());
                double amount= double.Parse(reader["amount"].ToString());
                Transaction transaction = new Transaction
                {
                    Id = transactionId,
                    FromAccountNumber = fromAccountNumber,
                    ToAccountNumber = toAccountNumber,
                    Date = transactionDate,
                    Amount = amount
                };
                transactions.Add(transaction);
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
        return transactions;
    }

        public async Task<Transaction> GetTransaction(int id)
        {
            Transaction transaction = new Transaction();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from transactions where id = @transactionId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@transactionId",id);
                await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(await reader.ReadAsync())
                {
                int transactionId = int.Parse(reader["id"].ToString());
                string fromAccountNumber = reader["fromaccountnumber"].ToString();
                string toAccountNumber = reader["toaccountnumber"].ToString();
                DateTime transactionDate = DateTime.Parse(reader["date"].ToString());
                double amount= double.Parse(reader["amount"].ToString());
                transaction = new Transaction
                {
                    Id = transactionId,
                    FromAccountNumber = fromAccountNumber,
                    ToAccountNumber = toAccountNumber,
                    Date = transactionDate,
                    Amount = amount
                };
               await reader.CloseAsync();
            }
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return transaction;
        }

        public async Task<bool> Insert(Transaction transaction)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Insert into transactions(fromaccountnumber,toaccountnumber,date,amount) VALUES(@fromAccountNumber,@toAccountNumber,@transactionDate,@amount)";
               await  con.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@fromAccountNumber",transaction.FromAccountNumber);
                cmd.Parameters.AddWithValue("@toAccountNumber",transaction.ToAccountNumber);
                cmd.Parameters.AddWithValue("@transactionDate",transaction.Date);
                cmd.Parameters.AddWithValue("@amount",transaction.Amount);
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
        public async Task<bool> Update(Transaction transaction)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Update transactions set  fromaccountnumber= @fromAccountNumber, toaccountnumber= @toAccountNumber, date = @transactionDate, amount=@amount where id = @transactionId";



                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@transactionId",transaction.Id);
                cmd.Parameters.AddWithValue("@fromAccountNumrber",transaction.FromAccountNumber);
                cmd.Parameters.AddWithValue("@toAccountNumber",transaction.ToAccountNumber);
                cmd.Parameters.AddWithValue("@transactionDate",transaction.Date);
                cmd.Parameters.AddWithValue("@amount",transaction.Amount);
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
                string query = "Delete from transactions Where id = @transactionId";
               await con.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@transactionId",id);
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


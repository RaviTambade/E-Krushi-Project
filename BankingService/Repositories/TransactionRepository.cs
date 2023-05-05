
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

        public List<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
        try{
            string query = "select * from transactions";
            MySqlCommand cmd = new MySqlCommand(query,con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int transactionId = int.Parse(reader["transaction_id"].ToString());
                string fromAccountNumber = reader["from_account_number"].ToString();
                string toAccountNumber = reader["to_account_number"].ToString();
                DateTime transactionDate = DateTime.Parse(reader["transaction_date"].ToString());
                double amount= double.Parse(reader["amount"].ToString());
                Transaction transaction = new Transaction
                {
                    TransactionId = transactionId,
                    FromAccountNumber = fromAccountNumber,
                    ToAccountNumber = toAccountNumber,
                    TransactionDate = transactionDate,
                    Amount = amount
                };
                transactions.Add(transaction);
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
        return transactions;
    }

        public Transaction GetTransaction(int id)
        {
            Transaction transaction = new Transaction();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "select * from transactions where transaction_id = @transactionId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@transactionId",id);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                int transactionId = int.Parse(reader["transaction_id"].ToString());
                string fromAccountNumber = reader["from_account_number"].ToString();
                string toAccountNumber = reader["to_account_number"].ToString();
                DateTime transactionDate = DateTime.Parse(reader["transaction_date"].ToString());
                double amount= double.Parse(reader["amount"].ToString());
                transaction = new Transaction
                {
                    TransactionId = transactionId,
                    FromAccountNumber = fromAccountNumber,
                    ToAccountNumber = toAccountNumber,
                    TransactionDate = transactionDate,
                    Amount = amount
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
            return transaction;
        }

        public bool InsertTransaction(Transaction transaction)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Insert into transactions(from_account_number,to_account_number,transaction_date,amount) VALUES(@fromAccountNumrber,@toAccountNumber,@transactionDate,@amount)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@fromAccountNumber",transaction.FromAccountNumber);
                cmd.Parameters.AddWithValue("@toAccountNumber",transaction.ToAccountNumber);
                cmd.Parameters.AddWithValue("@transactionDate",transaction.TransactionDate);
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
                con.Close();
            }
            return status;
        }
        public bool UpdateTransaction(Transaction transaction)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Update transactions set  from_account_number= @fromAccountNumber, to_account_number= @toAccountNumber, transaction_date = @transactionDate, amount=@amount where transaction_id = @transactionId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@transactionId",transaction.TransactionId);
                cmd.Parameters.AddWithValue("@fromAccountNumrber",transaction.FromAccountNumber);
                cmd.Parameters.AddWithValue("@toAccountNumber",transaction.ToAccountNumber);
                cmd.Parameters.AddWithValue("@transactionDate",transaction.TransactionDate);
                cmd.Parameters.AddWithValue("@amount",transaction.Amount);
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
        public bool DeleteTransaction(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try{
                string query = "Delete from transactions Where transaction_id = @transactionId";
                con.Open();
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
                con.Close();
            }
            return status;
        }
    }
}


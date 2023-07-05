using KrushiProject.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using KrushiProject.Models;

namespace KrushiProject.Repositories
{
      
    public class CustomerRepository : ICustomerRepository
    {
        public static string conString = "server=localhost; port=3306; user=root; password=PASSWORD; database=ekrushi";
       

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
        try{
            string query = "select * from customers";
            MySqlCommand cmd = new MySqlCommand(query,con);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(await reader.ReadAsync())
            {
                int Id = int.Parse(reader["id"].ToString());
                string firstName = reader["firstname"].ToString();
                string lastName = reader["lastname"].ToString();
                int userId = int.Parse(reader["userid"].ToString());
            
            Customer customer = new Customer()
            {
                Id = Id,
                FirstName = firstName,
                LastName = lastName,
                UserId = userId
            };
            customers.Add(customer);
            }
            await reader.CloseAsync();
        }
        catch(Exception e){
            throw e;
        }
        finally{
            await con.CloseAsync();
        }
        return customers;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = new Customer();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try{
                string query = "select * from customers where id = @customerId";
                await con.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@customerId",id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(await reader.ReadAsync())
                {
                    string firstName = reader["firstname"].ToString();
                    string lastName = reader["lastname"].ToString();
                    int userId = int.Parse(reader["userid"].ToString());  
                
                customer = new Customer()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    UserId = userId

                };
                }
                await reader.CloseAsync();
            }
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return customer;
        }
        public async Task<bool> Insert(Customer customer)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try{
                string query = "Insert into customers(firstname,lastname,userid) VALUES(@firstName,@lastName,@userId)";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@firstName",customer.FirstName);
                cmd.Parameters.AddWithValue("@lastName",customer.LastName);
                cmd.Parameters.AddWithValue("@userId",customer.UserId);
                con.Open();
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

        public async Task<bool> Update(Customer customer)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "update customers set firstname=@firstName, lastname=@lastName,userid = @userId  Where id= @customerId" ;
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@customerId",customer.Id);
                cmd.Parameters.AddWithValue("@firstName",customer.FirstName);
                cmd.Parameters.AddWithValue("@lastName",customer.LastName);
                cmd.Parameters.AddWithValue("@userId",customer.UserId);
               await con.OpenAsync();
                int rowsAffected = cmd.ExecuteNonQuery();
                {
                    if( rowsAffected > 0)
                    {
                        status = true;
                    }
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
            con.ConnectionString = conString;
            try
            {
                string query = "delete from customers where id = @customerId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("customerId",id);
                await con.OpenAsync();
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e)
            {
                 throw e;
            }
            finally
            {
               await con.CloseAsync();
            }
            return status;
        }
        public async Task<Customer> GetUser(int userId)
        {
            Customer customer = new Customer();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "select * from customers where id = @userId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@userId", userId);
               await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    int customerId = int.Parse(reader["id"].ToString());
                    string firstName = reader["firstname"].ToString();
                    string lastName = reader["lastname"].ToString();
                    //int userId = int.Parse(reader["user_id"].ToString());

                
                customer = new Customer()
                {
                    Id = customerId,
                    FirstName = firstName,
                    LastName = lastName,
                    UserId = userId

                };
                }
               await reader.CloseAsync();
            }
            catch(Exception e)
            {
                throw e;

            }
            finally
            {
               await con.CloseAsync();
            }
            return customer;
        }
    }
}

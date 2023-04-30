using KrushiProject.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using KrushiProject.Models;

namespace KrushiProject.Repositories
{
      
    public class CustomerRepository : ICustomerRepository
    {
        public static string conString = "server=localhost; port=3306; user=root; password=Password; database=E_Krushi";
       

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
        try{
            string query = "select * from customers";
            MySqlCommand cmd = new MySqlCommand(query,con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int customerId = int.Parse(reader["cust_id"].ToString());
                string firstName = reader["first_name"].ToString();
                string lastName = reader["last_name"].ToString();
                int userId = int.Parse(reader["user_id"].ToString());
            
            Customer customer = new Customer()
            {
                CustomerId = customerId,
                FirstName = firstName,
                LastName = lastName,
                UserId = userId
            };
            customers.Add(customer);
            }
            reader.Close();
        }
        catch(Exception e){
             throw e;
        }
        finally{
            con.Close();
        }
        return customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try{
                string query = "select * from customers where cust_id = @customerId";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@customerId",id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    string firstName = reader["first_name"].ToString();
                    string lastName = reader["last_name"].ToString();
                    int userId = int.Parse(reader["user_id"].ToString());  
                
                customer = new Customer()
                {
                    CustomerId = id,
                    FirstName = firstName,
                    LastName = lastName,
                    UserId = userId

                };
                }
                reader.Close();
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Close();
            }
            return customer;
        }
        public bool InsertCustomer(Customer customer)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try{
                string query = "Insert into customers(first_name,last_name,user_id) VALUES(@firstName,@lastName,@userId)";
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
                con.Close();
            }
            return status;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "update customers set first_name=@firstName, last_name=@lastName,user_id = @userId  Where cust_id= @customerId" ;
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@customerId",customer.CustomerId);
                cmd.Parameters.AddWithValue("@firstName",customer.FirstName);
                cmd.Parameters.AddWithValue("@lastName",customer.LastName);
                cmd.Parameters.AddWithValue("@userId",customer.UserId);
                con.Open();
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
                con.Close();  
            }
            return status;
        }

        public bool DeleteCustomer(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "delete from customers where cust_id = @customerId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("customerId",id);
                con.Open();
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
                con.Close();
            }
            return status;
        }
        public Customer GetUser(int userId)
        {
            Customer customer = new Customer();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "select * from customers where user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    int customerId = int.Parse(reader["cust_id"].ToString());
                    string firstName = reader["first_name"].ToString();
                    string lastName = reader["last_name"].ToString();
                    //int userId = int.Parse(reader["user_id"].ToString());

                
                customer = new Customer()
                {
                    CustomerId = customerId,
                    FirstName = firstName,
                    LastName = lastName,
                    UserId = userId

                };
                }
                reader.Close();
            }
            catch(Exception e)
            {
                throw e;

            }
            finally
            {
                con.Close();
            }
            return customer;
        }
    }
}

using KrushiProject.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using KrushiProject.Models;

namespace KrushiProject.Repositories
{
      
    public class CustomerRepository : ICustomerRepository
    {
        public static string conString = "server=localhost; port=3306; user=root; password=Password; database=ekrushi";
       

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
                string query = "select * from customers where id = @customerId";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@customerId",id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
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
        public bool Insert(Customer customer)
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
                con.Close();
            }
            return status;
        }

        public bool Update(Customer customer)
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

        public bool Delete(int id)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "delete from customers where id = @customerId";
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
                string query = "select * from customers where id = @userId";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
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

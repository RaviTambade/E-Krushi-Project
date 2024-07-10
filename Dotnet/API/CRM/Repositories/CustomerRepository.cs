using Transflower.EKrushi.CRM.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Transflower.EKrushi.CRM.Models;

namespace Transflower.EKrushi.CRM.Repositories
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CustomerRepository(IConfiguration configuration)
        {

            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from customers";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return customers;
        }

        public async Task<Customer> GetById(int id)
        {
            Customer customer = new Customer();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from customers where id = @customerId";
                await connection.OpenAsync();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerId", id);
                MySqlDataReader reader = command.ExecuteReader();
                if (await reader.ReadAsync())
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return customer;
        }
        public async Task<bool> Insert(Customer customer)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "Insert into customers(firstname,lastname,userid) VALUES(@firstName,@lastName,@userId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstName", customer.FirstName);
                command.Parameters.AddWithValue("@lastName", customer.LastName);
                command.Parameters.AddWithValue("@userId", customer.UserId);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }

        public async Task<bool> Update(Customer customer)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "update customers set firstname=@firstName, lastname=@lastName,userid = @userId  Where id= @customerId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerId", customer.Id);
                command.Parameters.AddWithValue("@firstName", customer.FirstName);
                command.Parameters.AddWithValue("@lastName", customer.LastName);
                command.Parameters.AddWithValue("@userId", customer.UserId);
                await connection.OpenAsync();
                int rowsAffected = command.ExecuteNonQuery();
                {
                    if (rowsAffected > 0)
                    {
                        status = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }

        public async Task<bool> Delete(int id)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "delete from customers where id = @customerId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("customerId", id);
                await connection.OpenAsync();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }
        public async Task<Customer> GetByUserId(int userId)
        {
            Customer customer = new Customer();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from customers where id = @userId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
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
            catch (Exception)
            {
                throw;

            }
            finally
            {
                await connection.CloseAsync();
            }
            return customer;
        }
    }
}

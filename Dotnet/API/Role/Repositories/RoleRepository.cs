using Transflower.EKrushi.Role.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Transflower.EKrushi.Role.Repositories.Interface;
namespace Transflower.EKrushi.Role.Repositories;

public class RoleRepository : IRoleRepository
{

    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public RoleRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }


    public async Task<List<UserRole>> GetAll()
    {
        List<UserRole> roles = new List<UserRole>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select * from roles";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();

            while (await reader.ReadAsync())
            {
                int roleid = int.Parse(reader["id"].ToString());
                string role = reader["role"].ToString();
                UserRole r1 = new UserRole
                {

                    Id = roleid,
                    Name = role
                };

                roles.Add(r1);

            };
        }
        catch (Exception ee)
        {
            throw ee;
        }

        finally
        {
            await connection.CloseAsync();
        }

        return roles;
    }


    public async Task<UserRole> GetById(int id)
    {
        UserRole role = new UserRole();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {

            string query = "select * from roles where id=@roleId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@roleId", id);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {

                int roleid = int.Parse(reader["id"].ToString());
                string RoleName = reader["role"].ToString();


                role = new UserRole()
                {

                    Id = roleid,
                    Name = RoleName

                };
            }
        }

        catch (Exception ee)
        {
            throw ee;
        }

        finally
        {

            await connection.CloseAsync();
        }

        return role;
    }


    public async Task<bool> Insert(UserRole role)
    {

        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {

            string query = "Insert into roles(role) values (@roleName)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@roleName", role.Name);
            await connection.OpenAsync();
            int rowsaffected = command.ExecuteNonQuery();

            if (rowsaffected > 0)
            {
                status = true;
            }
        }

        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {

            await connection.CloseAsync();
        }

        return status;

    }


    public async Task<bool> Update(UserRole role)
    {
        bool status = false;

        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;

        try
        {
            string query = "update roles set role=@roleName where id=@roleId";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            command.Parameters.AddWithValue("@roleId", role.Id);
            command.Parameters.AddWithValue("@roleName", role.Name);
            int rowsaffected = command.ExecuteNonQuery();

            if (rowsaffected > 0)
            {

                status = true;
            }
        }
        catch (Exception ee)
        {

            throw ee;
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

            string query = "delete from roles where id =@roleId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@roleId", id);

            await connection.OpenAsync();
            int rowsaffected = command.ExecuteNonQuery();
            if (rowsaffected > 0)
            {
                status = true;
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await connection.CloseAsync();
        }

        return status;
    }

    public async Task<List<string>> GetRolesOfUser(int id)
    {
        List<string> roles = new List<string>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select roles.role from roles inner join userroles on roles.id= userroles.roleid where userroles.userid=@userId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", id);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                string role = reader["role"].ToString();
                roles.Add(role);
                Console.WriteLine(roles);
            }
            await reader.CloseAsync();
        }

        catch (Exception ee)
        {
            throw ee;
        }

        finally
        {

            await connection.CloseAsync();
        }

        return roles;
    }
}







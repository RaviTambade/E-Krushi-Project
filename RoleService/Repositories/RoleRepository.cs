using E_krushiApp.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using E_krushiApp.Repositories.Interface;
namespace E_krushiApp.Repositories;

public class RoleRepository : IRoleRepository
{

    private readonly IConfiguration _configuration;
    private readonly string _conString;

    public RoleRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    
    public async Task<List<Role>> Roles()
    {
        List<Role> roles = new List<Role>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
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



                Role r1 = new Role
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


    public async Task<Role> Role(int id)
    {
        Role role = new Role();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
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


                role = new Role()
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


    public async Task<bool> Insert(Role role)
    {

        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
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


    public async Task<bool> Update(Role role)
    {
        bool status = false;

        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;

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



    public async Task<bool> Delete(int id){

        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString=_conString;
        try{

            string query= "delete from roles where id =@roleId";
            MySqlCommand command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@roleId",id);

           await connection.OpenAsync();
            int rowsaffected = command.ExecuteNonQuery();
            if(rowsaffected>0){
                status =true;
            }

        }

        catch(Exception ee){
            throw ee;
        }


        finally{
           await connection.CloseAsync();
        }

        return status;
    }
}







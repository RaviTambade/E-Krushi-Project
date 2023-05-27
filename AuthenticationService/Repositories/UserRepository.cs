using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthenticationService.Helpers;
using AuthenticationService.Models;
using AuthenticationService.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
namespace AuthenticationService.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _conString;
    private readonly AppSettings _appsettings;

    public UserRepository(IConfiguration configuration, IOptions<AppSettings> appSettings)
    {

        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
        _appsettings = appSettings.Value;
    }


    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        User user = await GetUser(request);

        // return null if user not found
        if (user == null) { return null; }
        // authentication successful so generate jwt token
        var token = await generateJwtToken(user);
        return new AuthenticateResponse(user, token);
    }

    private async Task<string> generateJwtToken(User user)

    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = System.Text.Encoding.ASCII.GetBytes(_appsettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(await AllClaims(user)),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
       SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private async Task<List<Claim>> AllClaims(User user)
    {
        List<Claim> claims = new List<Claim>();
        //you can add custom Claims here
        claims.Add(new Claim("id", user.Id.ToString()));
        List<string> roles = await GetRolesOfUser(user.Id);
        foreach (string role in roles)
        {
            claims.Add(new Claim("Roles", role));
        }
        return claims;
    }

    private async Task<User> GetUser(AuthenticateRequest request)
    {
        User user = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM users where email=@email AND password =@password";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@email", request.Email);
            command.Parameters.AddWithValue("@password", request.Password);
            MySqlDataReader reader = command.ExecuteReader();

            if (await reader.ReadAsync())
            {
                int userId = int.Parse(reader["id"].ToString());
                string userEmail = reader["email"].ToString();
                string userPassword = reader["password"].ToString();
                user = new User
                {
                    Id = userId,
                    Email = userEmail,
                    Password = userPassword
                };
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {

            throw ee;
        }
        finally
        {
            await con.CloseAsync();
        }
        return user;

    }

    private async Task<List<string>> GetRolesOfUser(int id)
    {
        List<string> roles = new List<string>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select roles.role from user_roles inner join roles on user_roles.role_id =roles.role_id where user_roles.user_id=@userId";
            Console.WriteLine(query);
            await con.OpenAsync();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                string roleName = reader["role"].ToString();
                // Console.WriteLine(roleName);
                roles.Add(roleName);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await con.CloseAsync();
        }
        return roles;
    }

    public async Task<List<User>> Users()
    {
        List<User> users = new List<User>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM users";
            await con.OpenAsync();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int userId = int.Parse(reader["id"].ToString());
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string contactNumber = reader["contactnumber"].ToString();
                User user = new User
                {
                    Id = userId,
                    Email = email,
                    Password = password,
                    ContactNumber = contactNumber
                };
                users.Add(user);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await con.CloseAsync();
        }
        return users;
    }

    public async Task<bool> Validate(AuthenticateRequest user)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT EXISTS(SELECT * FROM users where email=@email and password=@password)";
            command.Connection = connection;
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@password", user.Password);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            await reader.ReadAsync();
            if ((Int64)reader[0] == 1)
            {
                status = true;
            }
            await reader.CloseAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;

    }



    public async Task<User> User(int id){

        User user= new User();
        MySqlConnection connection =new MySqlConnection();
        connection.ConnectionString=_conString;
        try{

        string query= "select * from users where id ="+id;
         MySqlCommand cmd = new MySqlCommand(query,connection);
         await connection.OpenAsync();
         MySqlDataReader reader = cmd.ExecuteReader();
         if(await reader.ReadAsync()){


            string email= reader["email"].ToString();
            string password= reader["password"].ToString();
            string contactNumber= reader["contactnumber"].ToString();
         
             user = new User(){
                Id=id,
                Email= email,
                Password=password,
                ContactNumber=contactNumber

             };
           }
            await reader.CloseAsync();
        }
        catch(Exception ee){

            throw ee;
        }
        finally{
           await connection.CloseAsync();
        }
       return user;
    }


      public async Task<bool> Register(User user){

        bool status= false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString=_conString;

        try{
            string query="Insert into users(email,password,contactnumber) values (@email,@password,@contactNumber)";
            MySqlCommand cmd =new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@email",user.Email);
            cmd.Parameters.AddWithValue("@password",user.Password);
            cmd.Parameters.AddWithValue("@contactNumber",user.ContactNumber);
        await con.OpenAsync();
        int rowsaffected=cmd.ExecuteNonQuery();
        if(rowsaffected>0){

            status=true;
        }
        }

        catch(Exception ee){

            throw ee;
        }

        finally{

            await con.CloseAsync();
          }

          return status;

      }

      public async Task<bool> Update(User user){

        bool status= false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString=_conString;
        try{
            string query= "update users set email=@email,password=@password,contactnumber=@contactNumber where id=@userId" ;
            MySqlCommand command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@userId",user.Id);
            command.Parameters.AddWithValue("@email",user.Email);
            command.Parameters.AddWithValue("@password",user.Password);
            command.Parameters.AddWithValue("@contactNumber",user.ContactNumber);
            await connection.OpenAsync();
            int rowsaffected = command.ExecuteNonQuery();
            if(rowsaffected>0){
                status=true;
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


      public async Task<bool> Delete(int id){
        bool status = false;
        MySqlConnection connection =new MySqlConnection();
        connection.ConnectionString=_conString;
        try{

            string query= "delete from users where id=@userId";
            MySqlCommand command= new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@userId",id);
            await connection.OpenAsync();
            int rowsaffected = command.ExecuteNonQuery();
            if(rowsaffected>0){
                status=true;
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
    


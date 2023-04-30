using E_krushiApp.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using E_krushiApp.Repositories.Interface;
namespace E_krushiApp.Repositories;

public class UserRepository:IUserRepository{


    public string conString="server=localhost; user=root; port=3306; password=PASSWORD; database=E_krushi ";
    public  List<User> GetAllUsers(){
        List<User> users = new List<User>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString=conString;
       try
       {
        string query = "select * from users";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        connection.Open();
        
        MySqlDataReader reader= cmd.ExecuteReader();
        while(reader.Read()){
            int id = Int32.Parse(reader["user_id"].ToString());
            string email= reader["email"].ToString();
            string password= reader["password"].ToString();
            string contactNumber= reader["contact_number"].ToString();
        
         
         User user = new User{
            UserId = id,
            Email= email,
            Password=password,
            ContactNumber= contactNumber, 
         };

         users.Add(user);
        
       }
        reader.Close();
       }
       catch(Exception ee){
        throw ee;
       }
        
        finally{

        }
        connection.Close();
    
    return users;
    }

}
    
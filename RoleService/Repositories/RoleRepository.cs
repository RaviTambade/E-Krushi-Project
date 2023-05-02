using E_krushiApp.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using E_krushiApp.Repositories.Interface;
namespace E_krushiApp.Repositories;

      public class RoleRepository : IRoleRepository
    {

        public string conString= "server=localhost; port=3306; user=root; password=PASSWORD; database=E_krushi";
     public List<Role> GetAll()
        {
           List<Role> roles =new List<Role>();
           MySqlConnection connection = new MySqlConnection();
           connection.ConnectionString=conString;
           try{
            string query = "select * from roles";
            MySqlCommand command = new MySqlCommand(query,connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
                
            while (reader.Read()){


                int roleid = int.Parse(reader["role_id"].ToString());
                string role = reader["role"].ToString();



                Role r1 = new Role{
                    
                    RoleId=roleid,
                    RoleName=role
                    };

                roles.Add(r1);

            };
           }
            catch(Exception ee){
                throw ee;
            }

            finally{
                connection.Close();
            }

            return roles;
            }
            
    }
           

        

        
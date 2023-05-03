using E_krushiApp.Models;
using E_krushiApp.Repository.Interface.IAgriDoctor;
using MySql.Data.MySqlClient;
namespace E_krushiApp.Repositories;

public class Agri : IAgri
{

   public  static string conString ="server=localhost; user=root; password=PASSWORD; database=E_krushi";
    public List<AgriDoctor> GetAll(){


        List<AgriDoctor> doctors = new List<AgriDoctor>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString=conString;

        try{

            string query = "select * from agri_doctors";
            MySqlCommand command = new MySqlCommand(query,connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            
            while(reader.Read()){


                int doctorsID = int.Parse(reader["agri_doctor_id"].ToString());
                string name = reader["name"].ToString();
                string specialFor = reader["specialist_for"].ToString();
                int userId =int.Parse(reader["user_id"].ToString());

                AgriDoctor doctor =new AgriDoctor()
                {
                    
                    AgriDoctorId=doctorsID,
                    Name=name,
                    SpecialListFor=specialFor,
                    UserId=userId
                };


                  doctors.Add(doctor);
            

            }
           
        }
        catch(Exception ee){
            throw ee;
        }

        finally{

            connection.Close();
        }
        return doctors;
    }
     



     public AgriDoctor GetById(int id){

        AgriDoctor doctor = new AgriDoctor();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString=conString;

        try{

            string query="select * from agri_doctors where agri_doctor_id = @id";
            MySqlCommand command = new MySqlCommand(query,connection);
            connection.Open();
            command.Parameters.AddWithValue("@id",id);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read()){

               int doctorsID = int.Parse(reader["agri_doctor_id"].ToString());
                string name = reader["name"].ToString();
                string specialFor = reader["specialist_for"].ToString();
                int userId =int.Parse(reader["user_id"].ToString());

                 doctor =new AgriDoctor()
                {
                    
                    AgriDoctorId=doctorsID,
                    Name=name,
                    SpecialListFor=specialFor,
                    UserId=userId
                };



            }
        }

        catch(Exception ee){

            throw ee;
        }


        finally{
            connection.Close();
        }

        return doctor;
     }
   
}
using E_krushiApp.Models;
using E_krushiApp.Repository.Interface.IAgriDoctor;
using MySql.Data.MySqlClient;
namespace E_krushiApp.Repositories;

public class Agri : IAgri
{

    public static string conString = "server=localhost; user=root; password=PASSWORD; database=E_krushi";
    public List<AgriDoctor> GetAll()
    {


        List<AgriDoctor> doctors = new List<AgriDoctor>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "select * from agri_doctors";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {


                int doctorsID = int.Parse(reader["agri_doctor_id"].ToString());
                string name = reader["name"].ToString();
                string specialFor = reader["specialist_for"].ToString();
                int userId = int.Parse(reader["user_id"].ToString());

                AgriDoctor doctor = new AgriDoctor()
                {

                    AgriDoctorId = doctorsID,
                    Name = name,
                    SpecialListFor = specialFor,
                    UserId = userId
                };


                doctors.Add(doctor);


            }

        }
        catch (Exception ee)
        {
            throw ee;
        }

        finally
        {

            connection.Close();
        }
        return doctors;
    }




    public AgriDoctor GetById(int id)
    {

        AgriDoctor doctor = new AgriDoctor();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "select * from agri_doctors where agri_doctor_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

                int doctorsID = int.Parse(reader["agri_doctor_id"].ToString());
                string name = reader["name"].ToString();
                string specialFor = reader["specialist_for"].ToString();
                int userId = int.Parse(reader["user_id"].ToString());

                doctor = new AgriDoctor()
                {

                    AgriDoctorId = doctorsID,
                    Name = name,
                    SpecialListFor = specialFor,
                    UserId = userId
                };



            }
        }

        catch (Exception ee)
        {

            throw ee;
        }


        finally
        {
            connection.Close();
        }

        return doctor;
    }




    public bool InsertDoctor(AgriDoctor doctor)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "Insert into agri_doctors(agri_doctor_id,name,specialist_for,user_id) values(@doctorId,@name,@specialistfor,@userid)";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@doctorId", doctor.AgriDoctorId);
            command.Parameters.AddWithValue("@name", doctor.Name);
            command.Parameters.AddWithValue("@specialistfor", doctor.SpecialListFor);
            command.Parameters.AddWithValue("@userid", doctor.UserId);
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
            connection.Close();
        }

        return status;
    }



    public bool UpdateDoctor(AgriDoctor doctor)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "update agri_doctors set name=@name,specialist_for=@specialistFor,user_id=@Id where agri_doctor_id=@doctorId";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@name", doctor.Name);
            command.Parameters.AddWithValue("@doctorId", doctor.AgriDoctorId);
            command.Parameters.AddWithValue("@specialistFor", doctor.SpecialListFor);
            command.Parameters.AddWithValue("@Id", doctor.UserId);
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
            connection.Close();
        }

        return status;
    }




    public bool DeleteDoctor(int id)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = ("delete from agri_doctors where agri_doctor_id=@doctorId");
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@doctorId", id);
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
            connection.Close();
        }

        return status;
    }
}
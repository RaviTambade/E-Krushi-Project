using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using MySql.Data.MySqlClient;

namespace E_krushiApp.Repository;

public class QuestionSolutionRepository:IQuestionSolutionRepository{


    public static string conString ="server=localhost;port=3306;user=root;Password=PASSWORD;Database=E_krushi";

    public List<QuestionSolution> GetAll(){

        List<QuestionSolution> questionSolutions = new List<QuestionSolution>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString= conString;

        try{

            string query = "select * from question_solutions";
            MySqlCommand command = new MySqlCommand(query,connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
           
            while(reader.Read()){


                int questionId= int.Parse(reader["question_id"].ToString());
                 int solutionId= int.Parse(reader["solution_id"].ToString());
                DateTime solutionDate= DateTime.Parse(reader["solution_date"].ToString());
                int agriDoctorId =int.Parse(reader["agri_doctor_id"].ToString());
                


                QuestionSolution questionSolution = new QuestionSolution(){
                    QuestionId=questionId,
                    SolutionId=solutionId,
                    SolutionDate=solutionDate,
                    AgriDoctorId=agriDoctorId
                
                };

                questionSolutions.Add(questionSolution);
            }

        }
        catch(Exception ee){
            throw ee;
        }

        finally{
            connection.Close();
        }

        return questionSolutions;
    }


     public QuestionSolution GetById(int id)
    {

        QuestionSolution questionSolution = new QuestionSolution();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "select * from question_solutions where question_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

               int questionId= int.Parse(reader["question_id"].ToString());
                 int solutionId= int.Parse(reader["solution_id"].ToString());
                DateTime solutionDate= DateTime.Parse(reader["solution_date"].ToString());
                int agriDoctorId =int.Parse(reader["agri_doctor_id"].ToString());
                

                 questionSolution = new QuestionSolution{
                    QuestionId=questionId,
                    SolutionId=solutionId,
                    SolutionDate=solutionDate,
                    AgriDoctorId=agriDoctorId
                
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

        return questionSolution;
    }


     public bool InsertQuestionSolution(QuestionSolution questionSolution)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "Insert into question_solutions(question_id,solution_id,solution_date,agri_doctor_id) values(@questionId,@solutionId,@solutionDate,@doctorId)";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@questionId", questionSolution.QuestionId);
            command.Parameters.AddWithValue("@solutionId",questionSolution.SolutionId);
            command.Parameters.AddWithValue("@solutionDate", questionSolution.SolutionDate);
            command.Parameters.AddWithValue("@doctorId", questionSolution.AgriDoctorId);
           
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



    public bool UpdateQuestionSolution(QuestionSolution questionSolution)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "update question_solutions set solution_id=@solutionId,solution_date=@solutiondate,agri_doctors_id=@doctorId where question_id=@questionId";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
             command.Parameters.AddWithValue("@questionId", questionSolution.QuestionId);
            command.Parameters.AddWithValue("@solutionId",questionSolution.SolutionId);
            command.Parameters.AddWithValue("@solutionDate", questionSolution.SolutionDate);
            command.Parameters.AddWithValue("@doctorId", questionSolution.AgriDoctorId);
           
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




    public bool DeleteQuestionSolution(int id)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = ("delete from question_solutions where question_id=@questionId");
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@questionId", id);
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
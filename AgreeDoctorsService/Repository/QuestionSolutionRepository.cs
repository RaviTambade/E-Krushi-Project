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
}
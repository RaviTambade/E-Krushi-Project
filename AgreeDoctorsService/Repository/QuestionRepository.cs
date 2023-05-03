using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using MySql.Data.MySqlClient;

namespace E_krushiApp.Repository;

public class QuestionRepository:IQuestionRepository{


    public static string conString ="server=localhost;port=3306;user=root;Password=PASSWORD;Database=E_krushi";

    public List<Question> GetAll(){

        List<Question> questions = new List<Question>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString= conString;

        try{

            string query = "select * from questions";
            MySqlCommand command = new MySqlCommand(query,connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
           
            while(reader.Read()){


                int questionId= int.Parse(reader["question_id"].ToString());
                DateTime questionDate= DateTime.Parse(reader["question_date"].ToString());
                string description = reader["description"].ToString();
                int custId =int.Parse(reader["cust_id"].ToString());
                int categoryId = int.Parse(reader["category_id"].ToString());


                Question question = new Question(){
                    QuestionId=questionId,
                    QuestionDate=questionDate,
                    Description=description,
                    CustId=custId,
                    CategoryId=categoryId
                };

                questions.Add(question);
            }

        }
        catch(Exception ee){
            throw ee;
        }

        finally{
            connection.Close();
        }

        return questions;
    }
}
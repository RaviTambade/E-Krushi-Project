using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using MySql.Data.MySqlClient;

namespace E_krushiApp.Repository;

public class QuestionRepository:IQuestionRepository{


    public static string conString ="server=localhost;port=3306;user=root;Password=Password;Database=E_krushi";

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

     public Question GetById(int id)
    {

        Question question = new Question();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "select * from questions where question_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

               int questionId= int.Parse(reader["question_id"].ToString());
                DateTime questionDate= DateTime.Parse(reader["question_date"].ToString());
                string description = reader["description"].ToString();
                int custId =int.Parse(reader["cust_id"].ToString());
                int categoryId = int.Parse(reader["category_id"].ToString());


                 question = new Question{
                    QuestionId=questionId,
                    QuestionDate=questionDate,
                    Description=description,
                    CustId=custId,
                    CategoryId=categoryId
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

        return question;
    }




    public bool InsertQuestion(Question question)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "Insert into questions(question_id,question_date,description,cust_id,category_id) values(@questionId,@questionDate,@description,@custId,@categoryId)";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@questionId", question.QuestionId);
            command.Parameters.AddWithValue("questionDate", question.QuestionDate);
            command.Parameters.AddWithValue("@description", question.Description);
            command.Parameters.AddWithValue("@custId",question.CustId);
            command.Parameters.AddWithValue("@categoryId", question.CategoryId);
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



    public bool UpdateQuestion(Question question)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "update questions set question_date=@questionDate,description=@description,cust_id=@custId,category_id=@categoryId where question_id=@questionId";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@questionId", question.QuestionId);
            command.Parameters.AddWithValue("questionDate", question.QuestionDate);
            command.Parameters.AddWithValue("@description", question.Description);
            command.Parameters.AddWithValue("@custId",question.CustId);
            command.Parameters.AddWithValue("@categoryId", question.CategoryId);
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




    public bool DeleteQuestion(int id)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = ("delete from questions where question_id=@questionId");
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
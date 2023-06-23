using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using MySql.Data.MySqlClient;

namespace E_krushiApp.Repository;

public class ConsultingRepository : IConsultingRepository
{

    private readonly IConfiguration _configuration;
    private readonly string _conString;

    public ConsultingRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }


    public async Task<List<Question>> getAllQuestions()
    {

        List<Question> questions = new List<Question>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;

        try
        {

            string query = "select * from questions";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int Id = int.Parse(reader["id"].ToString());
                string description = reader["description"].ToString();
                int categoryId = int.Parse(reader["categoryid"].ToString());

                Question question = new Question()
                {
                    Id = Id,
                    Description = description,
                    CategoryId = categoryId
                };
                questions.Add(question);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questions;
    }

    public async Task<Question> getQuestion(int id)
    {

        Question question = new Question();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "select * from questions where id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int Id = int.Parse(reader["id"].ToString());
                string description = reader["description"].ToString();
                int categoryId = int.Parse(reader["categoryid"].ToString());
                question = new Question
                {
                    Id = Id,
                    Description = description,
                    CategoryId = categoryId
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
            await connection.CloseAsync();
        }
        return question;
    }


    public async Task<List<SubjectMatterExpert>> getAllExperts()
    {
        List<SubjectMatterExpert> experts = new List<SubjectMatterExpert>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "select * from subjectmatterexperts";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();

            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string expertise = reader["expertise"].ToString();
                int userId = int.Parse(reader["userid"].ToString());

                SubjectMatterExpert expert = new SubjectMatterExpert()
                {
                    Id = id,
                    Name = name,
                    Expertise = expertise,
                    UserId = userId
                };
                experts.Add(expert);
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
        return experts;
    }
    public async Task<SubjectMatterExpert> getExpert(int id)
    {
        SubjectMatterExpert doctor = new SubjectMatterExpert();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;

        try
        {

            string query = "select * from subjectmatterexperts where id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {

                int Id = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string expertise = reader["expertise"].ToString();
                int userId = int.Parse(reader["userid"].ToString());

                doctor = new SubjectMatterExpert()
                {

                    Id = Id,
                    Name = name,
                    Expertise = expertise,
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
            await connection.CloseAsync();
        }

        return doctor;
    }




    public async Task<List<Answer>> getAllAnswers()
    {
        List<Answer> answers = new List<Answer>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "select * from answers";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int Id = int.Parse(reader["id"].ToString());
                string description = reader["description"].ToString();
                int questionId = int.Parse(reader["questionid"].ToString());
                Answer answer = new Answer()
                {
                    Id = Id,
                    Description = description,
                    QuestionId = questionId
                };
                answers.Add(answer);
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

        return answers;
    }

    public async Task<List<Question>> listOfCategoryQuestions(int id)
    {
        List<Question> questions = new List<Question>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from questions where categoryid = @id";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int Id = int.Parse(reader["id"].ToString());
                string description = reader["description"].ToString();
                //int categoryId = int.Parse(reader["category_id"].ToString());
                Question question = new Question
                {
                    Id = Id,
                    Description = description,
                    CategoryId = id
                };
                questions.Add(question);
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
        return questions;
    }




    public async Task<List<QuestionAnswer>> getQuestionAnswers(int id)
    {
        List<QuestionAnswer> questionAnswers = new List<QuestionAnswer>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select (questions.description) as question,(answers.description) as answer from subjectmatterexperts,smeanswers ," +
                           "questions inner join answers on questions.id = answers.questionid where answers.id =smeanswers.answerid and subjectmatterexperts.id=smeanswers.smeid and smeanswers.smeid=@smeId";

            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@smeId", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                //int Id= int.Parse(reader["question_id"].ToString());
                string question = reader["question"].ToString();
                string answer = reader["answer"].ToString();

                QuestionAnswer questionAnswer = new QuestionAnswer
                {
                    SMEId = id,
                    Question = question,
                    Answer = answer

                };
                questionAnswers.Add(questionAnswer);
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
        return questionAnswers;
    }


    public async Task<List<Answer>> getAnswers(int id)
    {
        List<Answer> answers = new List<Answer>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from answers where questionid =@questionId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@questionId",id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                 int answerid = int.Parse(reader["id"].ToString());
                string description = reader["description"].ToString();
                int questionId = int.Parse(reader["questionid"].ToString());
                Answer ans = new Answer
                {
                    Id=answerid,
                    Description=description,
                    QuestionId=questionId

                };
                answers.Add(ans);
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
        return answers;
    }



    public async Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id)
    {

      List<SmeQuestion> questions = new  List<SmeQuestion>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "select questions.description from questions Inner join smeanswers on questions.id = smeanswers.questionid where smeanswers.smeid=@id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
               
                string description = reader["description"].ToString();
               
             SmeQuestion question = new SmeQuestion
                {
    
                    Question = description
                  
                };
                questions.Add(question);
            }
            await reader.CloseAsync();
        }
        catch (Exception ee)
        {

            throw ee;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questions;
    }


     public async Task<List<QuestionCategory>> getAllCategories(){

        List<QuestionCategory> categories = new List<QuestionCategory>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString=_conString;

        try{

            string query = "select * from questioncategories";
            MySqlCommand command =new MySqlCommand(query,connection);
           await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while(await reader.ReadAsync()){

                
                int Id = int.Parse(reader["id"].ToString());
                string Category= reader["category"].ToString();

                QuestionCategory category = new QuestionCategory{
                 Id=Id,
                 Category=Category

                };

                categories.Add(category);
            }

            await reader.CloseAsync();
        }

        catch(Exception ee){

            throw ee;

        }


        finally{

           await connection.CloseAsync();
        }


        return categories;


     }   
   


   public async Task<QuestionCategory> getQuestionCategory(int id){
         QuestionCategory Category = new QuestionCategory();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select id,category from questioncategories where id in(select id from questions where id=@id);";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int Id = int.Parse(reader["id"].ToString());
                string category= reader["category"].ToString();
                //int categoryId = int.Parse(reader["category_id"].ToString());
             Category = new QuestionCategory
                {
                    Id = Id,
                    Category = category
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
        return Category;
    }

     public async Task<bool> AddCustomerQuestion(CustomerQuestion question)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _conString;
            try
            {
                string query="Insert into customerquestions(questionid,custid,questiondate) VALUES(@questionId,@custId,@questionDate)";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.Parameters.AddWithValue("@questionId",question.QuestionId);
                cmd.Parameters.AddWithValue("@custId",question.CustomerId);
                cmd.Parameters.AddWithValue("@questionDate",question.QuestionDate);
                await con.OpenAsync();
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status=true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                await con.CloseAsync();
            }
            return status;
        }


    public async Task<List<CustomerQuestion>> getAllCustomerQuestion()
    {
       List<CustomerQuestion> customerQuestions = new List<CustomerQuestion>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from customerquestions";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                int questionId = int.Parse(reader["questionid"].ToString());
                int custId =int.Parse( reader["custid"].ToString());
                DateTime questionDate = DateTime.Parse(reader["questiondate"].ToString());
                CustomerQuestion customerQuestion = new CustomerQuestion
                {
                    Id=id,
                    QuestionId=questionId,
                    CustomerId=custId,
                    QuestionDate=questionDate

                };
                customerQuestions.Add(customerQuestion);
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
        return customerQuestions; 
    }
}




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


    public async Task<List<Question>> Questions()
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

    public async Task<Question> Question(int id)
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


    public async Task<List<SubjectMatterExpert>> Experts()
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
    public async Task<SubjectMatterExpert> Expert(int id)
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




    public async Task<List<Answer>> Answers()
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

    public async Task<List<Question>> Category(int id)
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




    public async Task<List<QuestionAnswer>> GetQuestionAnswers(int id)
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


    public async Task<List<Solution>> Answers(int id)
    {
        List<Solution> answers = new List<Solution>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select (description) as answer from answers where questionid =@questionId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@questionId", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {

                string? answer = reader["answer"].ToString();

                Solution ans = new Solution
                {
                    Answer = answer

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

    
}




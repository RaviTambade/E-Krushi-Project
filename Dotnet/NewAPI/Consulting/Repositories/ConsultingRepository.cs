using Transflower.EKrushi.Consulting.Models;
using Transflower.EKrushi.Consulting.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Transflower.EKrushi.Consulting.Repositories;

public class ConsultingRepository : IConsultingRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public ConsultingRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }


    public async Task<List<Question>> getAllQuestions()
    {
        List<Question> questions = new List<Question>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
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
        catch (Exception)
        {
            throw;
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
        connection.ConnectionString = _connectionString;
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
        catch (Exception)
        {

            throw;
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
        connection.ConnectionString = _connectionString;
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
        catch (Exception)
        {
            throw;
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
        connection.ConnectionString = _connectionString;
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

        catch (Exception)
        {

            throw ;
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
        connection.ConnectionString = _connectionString;
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
                    // Id = Id,
                    // Description = description,
                    // QuestionId = questionId
                };
                answers.Add(answer);
            }

        }
        catch (Exception )
        {
            throw ;
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
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select * from questions where categoryid = @id";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
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
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questions;
    }




    public async Task<List<QuestionAnswer>> getQuestionAnswers(int id)
    {
        List<QuestionAnswer> questionAnswers = new List<QuestionAnswer>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select (questions.description) as question,(answers.description) as answer from subjectmatterexperts,smeanswers ," +
                           "questions inner join answers on questions.id = answers.questionid where answers.id =smeanswers.answerid and subjectmatterexperts.id=smeanswers.smeid and smeanswers.smeid=@smeId";

            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
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
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questionAnswers;
    }


    public async Task<List<Answer>> getAnswers(int id)
    {
        List<Answer> answers = new List<Answer>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select (questions.description)as question,(questioncategories.category)as category,(answers.description)as answer from questions INNER join answers  on questions.id = answers.questionid INNER join questioncategories on questions.categoryid=questioncategories.id where questions.id =@questionId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@questionId", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                string question =reader["question"].ToString();
                string category = reader["category"].ToString();
                string answer =reader["answer"].ToString();
                Answer ans = new Answer
                {
                    Question = question,
                    Answers = answer,
                    Category = category

                };
                answers.Add(ans);
            }
            await reader.CloseAsync();
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return answers;
    }



    public async Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id)
    {

        List<SmeQuestion> questions = new List<SmeQuestion>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
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
        catch (Exception)
        {

            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questions;
    }


    public async Task<List<QuestionCategory>> getAllCategories()
    {

        List<QuestionCategory> categories = new List<QuestionCategory>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;

        try
        {

            string query = "select * from questioncategories";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {


                int Id = int.Parse(reader["id"].ToString());
                string Category = reader["category"].ToString();

                QuestionCategory category = new QuestionCategory
                {
                    Id = Id,
                    Category = Category

                };

                categories.Add(category);
            }

            await reader.CloseAsync();
        }

        catch (Exception)
        {

            throw ;

        }


        finally
        {

            await connection.CloseAsync();
        }


        return categories;


    }



    public async Task<QuestionCategory> getQuestionCategory(int id)
    {
        QuestionCategory Category = new QuestionCategory();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select id,category from questioncategories where id in(select id from questions where id=@id);";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int Id = int.Parse(reader["id"].ToString());
                string category = reader["category"].ToString();
                //int categoryId = int.Parse(reader["category_id"].ToString());
                Category = new QuestionCategory
                {
                    Id = Id,
                    Category = category
                };

            }
            await reader.CloseAsync();
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return Category;
    }

    public async Task<bool> AddCustomerQuestion(CustomerQuestion question)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "Insert into customerquestions(questionid,custid,questiondate) VALUES(@questionId,@custId,@questionDate)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@questionId", question.QuestionId);
            cmd.Parameters.AddWithValue("@custId", question.CustomerId);
            cmd.Parameters.AddWithValue("@questionDate", question.QuestionDate);
            await connection.OpenAsync();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }


    public async Task<List<CustomerQuestion>> getAllCustomerQuestion()
    {
        List<CustomerQuestion> customerQuestions = new List<CustomerQuestion>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select * from customerquestions";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                int questionId = int.Parse(reader["questionid"].ToString());
                int custId = int.Parse(reader["custid"].ToString());
                DateTime questionDate = DateTime.Parse(reader["questiondate"].ToString());
                CustomerQuestion customerQuestion = new CustomerQuestion
                {
                    Id = id,
                    QuestionId = questionId,
                    CustomerId = custId,
                    QuestionDate = questionDate

                };
                customerQuestions.Add(customerQuestion);
            }
            await reader.CloseAsync();
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return customerQuestions;
    }



    public async Task<List<NewQuestion>> QuestionDetailsByCustomer(int custId)
    {
        List<NewQuestion> questions = new List<NewQuestion>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "select customerquestions.id, questions.description,customerquestions.questiondate,(select count(*) from answers where questionid=customerquestions.questionid)as answers  from questions inner join customerquestions on customerquestions.questionid=questions.id where customerquestions.customerid=@custId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@custId", custId);

            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string description = reader["description"].ToString();
                DateTime questionDate = DateTime.Parse(reader["questiondate"].ToString());
                string answer = reader["answers"].ToString();

                NewQuestion question = new NewQuestion
                {
                    Id = id,
                    Description = description,
                    QuestionDate = questionDate,
                    Answers = answer
                };
                questions.Add(question);
            }
            await reader.CloseAsync();
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return questions;
    }

    public async Task<bool> InsertQuestion(Question question)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _connectionString;
        try
        {
            string query = "Insert into questions(description,categoryid) VALUES(@description,@categoryId)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@description", question.Description);
            cmd.Parameters.AddWithValue("@categoryId", question.CategoryId);
            await connection.OpenAsync();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await connection.CloseAsync();
        }
        return status;
    }




    public async Task<bool> DeleteQuestion(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query = "delete from customerquestions where id =@id";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            await con.OpenAsync();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }


    public async Task<List<Question>> GetQuestions(string categoryName)
    {

        List<Question> products = new List<Question>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query = "select questions.id ,questions.description,questions.categoryid from questions inner join questioncategories on questioncategories.id =questions.categoryid where questioncategories.category=@category";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@category", categoryName);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string description = reader["description"].ToString();
                int categoryId = int.Parse(reader["categoryid"].ToString());
                Question product = new Question()
                {
                    Id = id,
                    Description = description,
                    CategoryId = categoryId

                };
                products.Add(product);

            }
            await reader.CloseAsync();

        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await con.CloseAsync();
        }
        return products;
    }




    public async Task<int> GetCategoryId(string categoryName)
    {
        int categoryId = 0;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query = "select id from questioncategories where category =@categoryName";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@categoryName", categoryName);
            await con.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                categoryId = int.Parse(reader["id"].ToString());
            }
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await con.CloseAsync();
        }
        return (int)categoryId;
    }

    public async Task<List<QuestionAnswer>> CustomerQuestionAnswer(int questionId)
    {
        List<QuestionAnswer> answers = new List<QuestionAnswer>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query = "select distinct(questions.description)as question ,(answers.description) as answers from questions inner join answers on questions.id =answers.questionid inner join  customerquestions on customerquestions.questionid =questions.id where customerquestions.questionid=@questionId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@questionId", questionId);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                string question = reader["question"].ToString();
                string answer = reader["answers"].ToString();

                QuestionAnswer ans = new QuestionAnswer
                {
                    Question = question,
                    Answer = answer

                };
                answers.Add(ans);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw ;
        }
        finally
        {
            await con.CloseAsync();
        }
        return answers;
    }
}




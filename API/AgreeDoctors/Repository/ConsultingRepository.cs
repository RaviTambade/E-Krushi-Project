using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using MySql.Data.MySqlClient;

namespace E_krushiApp.Repository;

public class ConsultingRepository:IConsultingRepository{

 private readonly IConfiguration _configuration;
    private readonly string _conString;
   
    public ConsultingRepository(IConfiguration configuration )
    {

        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
   

    public async Task<List<Question>> Questions(){

        List<Question> questions = new List<Question>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString= _conString;

        try{

            string query = "select * from questions";
            MySqlCommand command = new MySqlCommand(query,connection);
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
           
            while(await reader.ReadAsync()){


                int Id= int.Parse(reader["question_id"].ToString());
                DateTime Date= DateTime.Parse(reader["question_date"].ToString());
                string description = reader["description"].ToString();
                int custId =int.Parse(reader["cust_id"].ToString());
                int categoryId = int.Parse(reader["category_id"].ToString());


                Question question = new Question(){
                    Id=Id,
                    Date=Date,
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
            await connection.CloseAsync();
        }

        return questions;
    }

     public async Task<Question> GetQuestion(int id)
    {

        Question question = new Question();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;

        try
        {

            string query = "select * from questions where question_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            await connection.OpenAsync();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {

               int Id= int.Parse(reader["question_id"].ToString());
                DateTime Date= DateTime.Parse(reader["question_date"].ToString());
                string description = reader["description"].ToString();
                int custId =int.Parse(reader["cust_id"].ToString());
                int categoryId = int.Parse(reader["category_id"].ToString());


                 question = new Question{
                    Id=Id,
                    Date=Date,
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
            await connection.CloseAsync();
        }

        return question;
    }

    List<Question> IConsultingRepository.Questions()
    {
        throw new NotImplementedException();
    }

    Question IConsultingRepository.GetQuestion(int id)
    {
        throw new NotImplementedException();
    }
}
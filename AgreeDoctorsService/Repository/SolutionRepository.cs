using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using MySql.Data.MySqlClient;

namespace E_krushiApp.Repository;

public class SolutionRepository:ISolutionRepository{


    public static string conString ="server=localhost;port=3306;user=root;Password=PASSWORD;Database=E_krushi";

    public List<Solution> GetAll(){

        List<Solution> solutions = new List<Solution>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString= conString;

        try{

            string query = "select * from solutionss";
            MySqlCommand command = new MySqlCommand(query,connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
           
            while(reader.Read()){


                int solutionId= int.Parse(reader["solution_id"].ToString());
                string description = reader["description"].ToString();
               

                Solution solution = new Solution(){
                    SolutionId=solutionId,
                    
                    Description=description,
                   
                };

                solutions.Add(solution);
            }

        }
        catch(Exception ee){
            throw ee;
        }

        finally{
            connection.Close();
        }

        return solutions;
    }

     public Solution GetById(int id)
    {

        Solution solution = new Solution();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "select * from solutions where solution_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

              int solutionId= int.Parse(reader["solution_id"].ToString());
                string description = reader["description"].ToString();
               

                 solution = new Solution(){
                    SolutionId=solutionId,
                    
                    Description=description,
                   
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

        return solution;
    }




    public bool InsertSolution(Solution solution)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "Insert into solutions(solution_id,description) values(@solutionId,@description)";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@solutionId", solution.SolutionId);
            
            command.Parameters.AddWithValue("@description", solution.Description);
            
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



    public bool UpdateSolution(Solution solution)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = "update solutions set description=@description where solution_id=@solutionId";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@solutionId", solution.SolutionId);
            
            command.Parameters.AddWithValue("@description", solution.Description);
            
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




    public bool DeleteSolution(int id)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;

        try
        {

            string query = ("delete from solutions where solution_id=@solutionId");
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@solutionId", id);
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

    public bool UpdateDoctor(Solution solution)
    {
        throw new NotImplementedException();
    }
}
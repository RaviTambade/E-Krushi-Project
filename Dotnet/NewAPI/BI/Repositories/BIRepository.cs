using System.Data;
using Transflower.EKrushi.BIService.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using Stores.Models;

namespace Transflower.EKrushi.BIService.Repositories;
public class BIRepository : IBIRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public BIRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public OrderSp OrdersStoredProcedure(DateTime todaysDate,int storeId)

    {
        OrderSp  orders= new OrderSp();
        

        MySqlConnection con = new MySqlConnection(_connectionString);

        //Create Command Object

        try{

            con.Open();

            MySqlCommand cmd = new MySqlCommand("GetOrdersByDate", con as MySqlConnection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@given_date",todaysDate);
             cmd.Parameters.AddWithValue("@givenStoreId",storeId);

            

            cmd.Parameters.AddWithValue("@todaysOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@yesterdaysOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@weekOrders", MySqlDbType.Int32);
            cmd.Parameters.AddWithValue("@monthOrders", MySqlDbType.Int32);

            cmd.Parameters["@todaysOrders"].Direction=ParameterDirection.Output;
            cmd.Parameters["@yesterdaysOrders"].Direction=ParameterDirection.Output;
            cmd.Parameters["@weekOrders"].Direction=ParameterDirection.Output;
            cmd.Parameters["@monthOrders"].Direction=ParameterDirection.Output;

            int rowsAffected = cmd.ExecuteNonQuery();
            

             orders.TodaysOrders =(int)cmd.Parameters["@todaysOrders"].Value;
             orders.YesterdaysOrders =(int)cmd.Parameters["@yesterdaysOrders"].Value;
             orders.WeekOrders =(int)cmd.Parameters["@weekOrders"].Value;
             orders.MonthOrders =(int)cmd.Parameters["@monthOrders"].Value;

           
        }

        catch (Exception e)

        {

            throw e;

        }

        finally

        {

            con.Close();

        }

        return orders;

    }


     public List<TopProducts> GetTopProducts(DateTime todaysDate,string mode)

    {
        List<TopProducts>  products= new List<TopProducts>();
        

        MySqlConnection con = new MySqlConnection(_connectionString);

        //Create Command Object

        try{

            con.Open();

            MySqlCommand cmd = new MySqlCommand("GetTopProducts", con as MySqlConnection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@given_date",todaysDate);
             cmd.Parameters.AddWithValue("@MODE",mode);
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read()){

               TopProducts product = new TopProducts(){
               ProductId = reader.GetInt32("productId"),
               TotalQuantity= reader.GetInt32("TotalQuantity"),
               Title=reader.GetString("title")
              };

              products.Add(product);


            }
             
            // int rowsAffected = cmd.ExecuteNonQuery();
            

            //  orders.ProductId =(int)cmd.Parameters["productId"].Value;
            //  orders.TotalQuantity =(int)cmd.Parameters["TotalQuantity"].Value;
            // //  orders.Title =cmd.Parameters["title"].Value;
            

           
        }

        catch (Exception e)

        {

            throw e;

        }

        finally

        {

            con.Close();

        }

        return products;

    }

}
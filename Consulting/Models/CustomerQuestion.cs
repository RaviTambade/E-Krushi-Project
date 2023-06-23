namespace E_krushiApp.Models;
public class CustomerQuestion{

    public int Id{get;set;}
    public int QuestionId{get;set;}
    public int CustomerId{get;set;}
    public DateTime QuestionDate{get;set;}
    public string Description{get;set;}
}
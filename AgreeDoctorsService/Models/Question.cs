namespace E_krushiApp.Models;
public class Question{

    public int QuestionId{get;set;}
    public DateTime QuestionDate{get;set;}

    public string Description{get;set;}

    public int CustId{get;set;}

    public int CategoryId{get;set;}
}
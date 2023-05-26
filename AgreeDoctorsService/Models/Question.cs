namespace E_krushiApp.Models;
public class Question{

    public int Id{get;set;}
    public DateTime Date{get;set;}
    public string Description{get;set;}
    public int CustId{get;set;}
    public int CategoryId{get;set;}
}
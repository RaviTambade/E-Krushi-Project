namespace E_krushiApp.BillingService.Models;
public class Billing{

    public int Id{get; set;}
    public int CustId{get; set;}
    public int OrderId{get; set;}
    public int TotalAmount{get; set;}
    public int Discount{get; set;}
    public DateTime Date{get; set;}

}
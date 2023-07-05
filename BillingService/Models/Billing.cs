namespace E_krushiApp.BillingService.Models;
public class Billing{

    public int Id{get; set;}
    public int Custid{get; set;}
    public int ProductId{get; set;}
    public int Quantity{get; set;}
    public int Discount{get; set;}
    public DateTime Date{get; set;}

}
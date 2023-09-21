namespace Transflower.EKrushi.OrderManagement.Models;

public class CustomerOrder{
    public int Id{get; set;}
    public string Status{get; set;}
    public DateTime OrderDate{get;set;}
    public DateTime ShippedDate{get;set;}
    public double Total{get; set;}

}
namespace OrderProcessingService.Models;

public class Order{
    public int Id{get; set;}

    public DateTime OrderDate{get; set;}

    public DateTime ShippedDate{get; set;}

    public int CustomerId{get; set;}

    public double Total{get; set;}

    public string Status{get; set;}
}
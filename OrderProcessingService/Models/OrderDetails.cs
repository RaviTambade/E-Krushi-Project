namespace OrderProcessingService.Models;

public class OrderDetails{

    public int OrderDetailsId{get; set;}

    public int OrderId{get; set;}

    public int ProductId{get; set;}

    public int Quantity{get; set;}

    public double Discount{get; set;}
}
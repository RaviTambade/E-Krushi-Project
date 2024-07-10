namespace TransFlower.EKrushi.Shippers.Models;

public class ShipperOrder
{
    public int OrderId { get; set; }
    public int FromAddressId { get; set; }
    public int ToAddressId { get; set; }
    public string? Status { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }
}

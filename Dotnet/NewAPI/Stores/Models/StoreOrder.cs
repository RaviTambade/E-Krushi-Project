namespace Transflower.EKrushi.Stores.Models;

public class StoreOrder
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }
    public string? Status { get; set; }
    public double Total { get; set; }
}

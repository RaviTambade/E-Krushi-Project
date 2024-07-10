namespace Transflower.EKrushi.Orders.Models;

public class OrderDetailModel
{
    public int ProductId { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public double UnitPrice { get; set; }
    public string? Size { get; set; }
    public int Quantity { get; set; }
    public double Total { get; set; }
}

namespace Transflower.EKrushi.Orders.Models;

public class OrderAddModel
{
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    public List<OrderDetailAddModel>? OrderDetails { get; set; }
}

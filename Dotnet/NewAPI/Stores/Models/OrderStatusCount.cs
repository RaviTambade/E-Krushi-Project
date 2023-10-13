namespace Transflower.EKrushi.Stores.Models;

public class OrderStatusCount
{
    public int Pending { get; set; }
    public int Approved { get; set; }
    public int ReadyToDispatch { get; set; }
    public int Picked { get; set; }
    public int InProgress { get; set; }
    public int Delivered { get; set; }
    public int Cancelled { get; set; }
}

namespace TransFlower.EKrushi.Shippers.Models;

public class OrderStatusCount
{
    public int ReadyToDispatch { get; set; }
    public int Picked { get; set; }
    public int InProgress { get; set; }
    public int Delivered { get; set; }
    public int Cancelled { get; set; }
}

namespace Transflower.EKrushi.Orders.Models;

public class OrderStatus
{
    public static readonly string Pending = "pending";
    public static readonly string Approved = "approved";
    public static readonly string ReadyToDispatch = "ready to dispatch";
    public static readonly string Picked = "picked";
    public static readonly string InProgress = "inprogress";
    public static readonly  string Delivered = "delivered";
    public static readonly string Cancelled = "cancelled";
}

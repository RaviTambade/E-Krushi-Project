public class PaymentAddModel
{
    public required string Mode { get; set; }
    public required string PaymentStatus { get; set; }
    public int? TransactionId { get; set; }
    public int OrderId { get; set; }
}

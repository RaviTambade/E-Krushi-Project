namespace BankingService.Models;

public class Transaction{
    public int TransactionId{get; set;}
    public string FromAccountNumber{get; set;}
    public string ToAccountNumber{ get; set; }
    public DateTime TransactionDate{ get; set; }
    public double Amount{ get; set; }
}
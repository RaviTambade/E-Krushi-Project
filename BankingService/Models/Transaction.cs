namespace BankingService.Models;

public class Transaction{
    public int Id{get; set;}
    public string FromAccountNumber{get; set;}
    public string ToAccountNumber{ get; set; }
    public DateTime Date{ get; set; }
    public double Amount{ get; set; }
}
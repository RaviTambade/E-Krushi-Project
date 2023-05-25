namespace BankingService.Models;

public class Account{
    public int Id{get; set;}
    public string Number{ get; set; }
    public string IFSCCode{ get; set; }
    public DateTime RegisterDate{ get; set; }
    public int UserId{ get; set; }
}
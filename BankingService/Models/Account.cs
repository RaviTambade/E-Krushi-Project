namespace AccountService.Models;

public class Account{
    public int AccountId{get; set;}
    public string AccountNumber{ get; set; }
    public string IFSCCode{ get; set; }
    public DateTime RegisterDate{ get; set; }
    public int UserId{ get; set; }
}
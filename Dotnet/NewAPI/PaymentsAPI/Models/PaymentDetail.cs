

namespace  Transflower.EKrushi.PaymentsAPI.Models;

public class PaymentDetail{


    public int PaymentId{get;set;}
    public DateTime Date{get;set;}
    public double Total{get;set;}
    public  string? Status{get;set;}
    public string? PaymentMode{get;set;}
}
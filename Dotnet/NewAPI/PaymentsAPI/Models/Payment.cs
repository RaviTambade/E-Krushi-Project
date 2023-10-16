

namespace  Transflower.EKrushi.PaymentsAPI.Models;

public class Payment{

    public DateTime PaymentDate{get;set;}
    public int OrderId{get;set;}
    public  string? PaymentStatus{get;set;}

}
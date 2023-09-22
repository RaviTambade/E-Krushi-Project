using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.PaymentsAPI.InterFaces;

using Transflower.EKrushi.PaymentsAPI.Models;
namespace Transflower.EKrushi.PaymentsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    
    private readonly IPaymentService _paymentservice;

    public PaymentController(IPaymentService paymentservice)
    {
        _paymentservice = paymentservice;
    }


     [HttpGet("{customerid}")]
     public  List<Payment> GetPayments(int customerid)
        {
            List<Payment> payments = _paymentservice.GetPayments(customerid);
            return payments;
        }

}

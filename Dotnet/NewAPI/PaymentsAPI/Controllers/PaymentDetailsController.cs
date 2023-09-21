using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.PaymentsAPI.InterFaces;

using Transflower.EKrushi.PaymentsAPI.Models;
namespace Transflower.EKrushi.PaymentsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentDetailsController : ControllerBase
{
    
    private readonly IPaymentDetailsService _paymentdetailsservice;

    public PaymentDetailsController(IPaymentDetailsService paymentdetailsservice)
    {
        _paymentdetailsservice = paymentdetailsservice;
    }


     [HttpGet("{orderid}")]
     public  PaymentDetails GetPaymentDetails(int orderid)
        {
            PaymentDetails paymentDetails = _paymentdetailsservice.GetPaymentDetails(orderid);
            return paymentDetails;
        }

}

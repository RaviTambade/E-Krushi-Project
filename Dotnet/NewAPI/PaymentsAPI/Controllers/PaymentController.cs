using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.PaymentsAPI.InterFaces;

using Transflower.EKrushi.PaymentsAPI.Models;

namespace Transflower.EKrushi.PaymentsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _service;

    public PaymentController(IPaymentService service)
    {
        _service = service;
    }

    [HttpGet("{customerid}")]
    public List<Payment> GetPayments(int customerid)
    {
        List<Payment> payments = _service.GetPayments(customerid);
        return payments;
    }
    [HttpPost]
    public async Task<bool> AddPayment(PaymentAddModel payment)
    {
        return await _service.AddPayment(payment);
    }
}

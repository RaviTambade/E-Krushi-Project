using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.PaymentsAPI.Interfaces;

using Transflower.EKrushi.PaymentsAPI.Models;

namespace Transflower.EKrushi.PaymentsAPI.Controllers;

[ApiController]
[Route("/api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _service;

    public PaymentsController(IPaymentService service)
    {
        _service = service;
    }

    [HttpGet("{customerId}")]
    public async Task<List<Payment>> GetPayments(int customerId)
    {
        return await _service.GetPayments(customerId);
    }

    [HttpPost]
    public async Task<bool> AddPayment(PaymentAddModel payment)
    {
        return await _service.AddPayment(payment);
    }

    [HttpGet("details/{orderId}")]
    public async Task<PaymentDetail> GetPaymentDetails(int orderId)
    {
        return await _service.GetPaymentDetails(orderId);
    }
}

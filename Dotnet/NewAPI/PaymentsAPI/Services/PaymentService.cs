using Transflower.EKrushi.PaymentsAPI.Interfaces;
using Transflower.EKrushi.PaymentsAPI.Models;
using Transflower.EKrushi.PaymentsAPI.Repositories.Interfaces;

namespace Transflower.EKrushi.PaymentsAPI.PaymentDetailsRepository;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddPayment(PaymentAddModel payment)
    {
        return await _repository.AddPayment(payment);
    }

    public async Task<PaymentDetail> GetPaymentDetails(int orderId)
    {
        return await _repository.GetPaymentDetails(orderId);
    }

    public async Task<List<Payment>> GetPayments(int customerId)
    {
        return await _repository.GetPayments(customerId);
    }
}

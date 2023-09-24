using Transflower.EKrushi.PaymentsAPI.InterFaces;
using Transflower.EKrushi.PaymentsAPI.Models;
using Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

namespace Transflower.EKrushi.PaymentsAPI.PaymentDetailsRepository;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddPayment(PaymentAddModel payment) =>
        await _repository.AddPayment(payment);

    public List<Payment> GetPayments(int customerid) => _repository.GetPayments(customerid);
}

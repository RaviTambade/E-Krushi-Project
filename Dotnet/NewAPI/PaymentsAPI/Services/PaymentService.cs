using Transflower.EKrushi.PaymentsAPI.InterFaces;
using Transflower.EKrushi.PaymentsAPI.Models;
using Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

namespace Transflower.EKrushi.PaymentsAPI.PaymentDetailsRepository;
public class PaymentService : IPaymentService
{


 private readonly IPaymentRepository _repo;
    public PaymentService(IPaymentRepository repo)
    {
        this._repo = repo;
    }
    public List<Payment> GetPayments(int customerid) => _repo.GetPayments(customerid);

    
}
using Transflower.EKrushi.PaymentsAPI.InterFaces;
using Transflower.EKrushi.PaymentsAPI.Models;
using Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

namespace Transflower.EKrushi.PaymentsAPI.PaymentDetailsRepository;
public class PaymentDetailsService : IPaymentDetailsService
{


 private readonly IPaymentDetailsRepository _repo;
    public PaymentDetailsService(IPaymentDetailsRepository repo)
    {
        this._repo = repo;
    }
    public PaymentDetails GetPaymentDetails(int orderid) => _repo.GetPaymentDetails(orderid);

}
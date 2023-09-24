using Transflower.EKrushi.PaymentsAPI.Models;

namespace Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

public interface IPaymentRepository{

    List<Payment> GetPayments(int customerid);
    Task<bool> AddPayment(PaymentAddModel payment);
}
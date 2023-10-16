using Transflower.EKrushi.PaymentsAPI.Models;

namespace Transflower.EKrushi.PaymentsAPI.Repositories.Interfaces;

public interface IPaymentRepository{

    Task<List<Payment>> GetPayments(int customerId);
    Task<bool> AddPayment(PaymentAddModel payment);
    Task<PaymentDetail> GetPaymentDetails(int orderId);

}
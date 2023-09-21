

using Transflower.EKrushi.PaymentsAPI.Models;

namespace Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

public interface IPaymentDetailsRepository{

    public PaymentDetails GetPaymentDetails(int orderid);
}
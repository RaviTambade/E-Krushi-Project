using Transflower.EKrushi.PaymentsAPI.Models;

namespace Transflower.EKrushi.PaymentsAPI.Repositories.InterFaces;

public interface IPaymentRepository{

    public List<Payment> GetPayments(int customerid);
}
using E_krushiApp.BillingService.Models;
namespace E_krushiApp.BillingService.Interfaces;
public interface IBillingRepository{


public Task<bool> AddBill( Billing bill);
}
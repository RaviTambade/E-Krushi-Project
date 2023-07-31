using E_krushiApp.BillingService.Interfaces;
using E_krushiApp.BillingService.Models;

namespace E_krushiApp.BillingService.Services;

public class BillingService : IBillingService
{

    private readonly IBillingRepository _repo;
    public BillingService(IBillingRepository  repo){

        _repo=repo;

    }
   
   
    public async Task<bool> AddBill(Billing bill)=> await _repo.AddBill(bill);
    
}
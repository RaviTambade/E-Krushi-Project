using E_krushiApp.BillingService.Models;
using E_krushiApp.BillingService.Interfaces;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("/api/[controller]")]
public class BillingController:ControllerBase{
    

    private readonly IBillingService _srv;

    public BillingController(IBillingService srv){
        _srv=srv;
    }

[HttpPost]
    [Route ("insertBill")]
     public async Task<bool> AddBill([FromBody] Billing bill)
   {    
        bool result = await _srv.AddBill(bill);
        return result;
   }
 }
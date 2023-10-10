
using Microsoft.AspNetCore.Mvc;
using Stores.Models;
using Transflower.EKrushi.BIService.Services.Interfaces;

namespace BIService.Controllers
{
    [ApiController]
    [Route("api/bi")]
    public class BIController : ControllerBase
    {
        private readonly IBIService _service;
        public BIController(IBIService svc)
        {
        _service = svc;
        } 

      

      [HttpGet("orderscount/{todaysDate}/{storeId}")]
    public OrderSp OrdersStoredProcedure(DateTime todaysDate,int storeId)
    {
        return _service.OrdersStoredProcedure(todaysDate,storeId);
    }



     [HttpGet("TopProducts/{todaysDate}/{mode}")]
    public List<TopProducts> GetTopProducts(DateTime todaysDate,string mode)
    {
        return _service.GetTopProducts(todaysDate,mode);
    }
    }
}
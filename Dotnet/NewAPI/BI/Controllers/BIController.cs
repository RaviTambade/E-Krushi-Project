using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.BIService.Models;
using Transflower.EKrushi.BIService.Services.Interfaces;

namespace Transflower.EKrushi.BIService.Controllers
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
        public async Task<OrderCount> OrdersCountByStore(DateTime todaysDate, int storeId)
        {
            return await _service.OrdersCountByStore(todaysDate, storeId);
        }

        [HttpGet("topproducts/{todaysDate}/{mode}/{storeId}")]
        public async Task<List<TopProducts>> GetTopFiveSellingProducts(DateTime todaysDate, string mode,int storeId)
        {
            return await _service.GetTopFiveSellingProducts(todaysDate, mode,storeId);
        }



         [HttpGet("MonthOrders/{year}/{storeId}")]
        public async Task<List<MonthOrders>> GetMonthOrders(int year,int storeId)
        {
             List<MonthOrders> orders=await _service.GetMonthOrders(year,storeId);
            return orders; 
        }

    }
}

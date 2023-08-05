using BIService.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using BIService.Services.Interfaces;

namespace BIService.Controllers
{
    [ApiController]
    [Route("api/bi")]
    public class BIController : ControllerBase
    {
        private readonly IBIService _svc;
        public BIController(IBIService svc)
        {
        _svc = svc;
        } 

        [HttpGet("Count/month/{year}")]                    //This query gives count of order by date
        public async Task<List<OrderChart>> GetCountByMonth(int year)
        {  
            Console.WriteLine(year);
            List<OrderChart> counts = await _svc.GetCountByMonth(year);
            return counts;
        }


        [HttpGet("Order/{year}")]                    //This query gives count of order by date
        public async Task<List<OrderChart>> OrderStatus(int year)
        {     
            Console.WriteLine(year);
            List<OrderChart> counts = await _svc.OrderStatus(year);
            return counts;
        }

        [HttpGet]
        [Route("sale/{year}")]
        public async Task<List<ProductSale>> GetProductReport(int year)
        {
            List<ProductSale> products = await _svc.GetProductReport(year);
            return products;
        }
    }
}
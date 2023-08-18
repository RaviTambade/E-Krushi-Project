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

        [HttpGet]
        [Route ("details/{custId}")]
        public async Task<List<CustomerReport>> GetCustomerReport(int custId)
        {
            List<CustomerReport> customers = await _svc.GetCustomerReport(custId);
            return customers;
        } 

        [HttpGet("smereport/{year}")]
        public async Task<List<SMEReport>> GetSMEReport(int year)
        {
            List<SMEReport> answers = await _svc.GetSMEReport(year);
            return answers;
        }

        [HttpGet("totalrevenue/{year}")]
        public async Task<List<OrderChart>> GetTotalRevenue(int year)
        {
            List<OrderChart> answers = await _svc.GetTotalRevenue(year);
            return answers;
        }

        [HttpGet("weekly/{year}")]
        public async Task<List<OrderChart>> GetWeeklyOrders(int year)
        {
            List<OrderChart> orders = await _svc.GetWeeklyOrders(year);
            return orders;
        }

        [HttpGet("yearly")]
        public async Task<List<OrderChart>> GetYearlyOrders()
        {
            List<OrderChart> orders = await _svc.GetYearlyOrders();
            return orders;
        }

        [HttpGet("yearly/sme")]
        public async Task<List<OrderChart>> GetYearlySMEPerformance()
        {
            List<OrderChart> orders = await _svc.GetYearlySMEPerformance();
            return orders;
        }




        
    }
}
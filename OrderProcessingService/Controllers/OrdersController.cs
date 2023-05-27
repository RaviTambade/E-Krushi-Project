using OrderProcessingService.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using OrderProcessingService.Services.Interfaces;

namespace OrderProcessingService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _ordersvc;
        public OrdersController(IOrderService ordersvc)
        {
        _ordersvc = ordersvc;
        } 

        [HttpGet("orders")]          
        public IEnumerable<Order> Orders()
        {
            List<Order> orders = _ordersvc.Orders();
            return orders;
        }

        [HttpGet("getorder/{id}")]
        public Order GetById(int id)
        {
            Order order = _ordersvc.GetOrder(id);
            return order;
        }

        [HttpPost("insert")]
        public bool Insert([FromBody] Order order)
        {
            bool status =_ordersvc.Insert(order);
            return status;
        }

        [HttpPut("update/{id}")]
        public bool Update(int id,[FromBody] Order order)
        {
            Order oldOrder = _ordersvc.GetOrder(id);
            if(oldOrder.OrderId==0)
            {
                return false;
            }
            order.OrderId =id;
            bool status = _ordersvc.Update(order);
            return status;
        }

        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _ordersvc.Delete(id);
            return status;
        }



        [HttpGet("Count/{date}")]                    //This query gives count of order by date
        public int GetCountByDate(DateTime date)
        {
            
            Console.WriteLine(date);
            int counts = _ordersvc.GetCountByDate(date);
            return counts;
        }
                                                      
        [HttpGet("totalcount")]                     //This query gives total count of orders
        public int TotalCount()
        {
            int totalCounts = _ordersvc.TotalCount();
            return totalCounts;
        }

    }
}
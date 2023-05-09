using OrderProcessingService.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Caching.Memory;
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

        [HttpGet]
        [Route("getallorders")]
        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> orders = _ordersvc.GetAllOrders();
            return orders;
        }

        [HttpGet]
        [Route("getorder/{id}")]
        public Order GetById(int id)
        {
            Order order = _ordersvc.GetOrder(id);
            return order;
        }

        [HttpPost]
        [Route("insertorder")]
        public bool InsertOrder([FromBody] Order order)
        {
            bool status =_ordersvc.InsertOrder(order);
            return status;
        }

        [HttpPut]
        [Route("updateorder/{id}")]
        public bool UpdateOrder(int id,[FromBody] Order order)
        {
            Order oldOrder = _ordersvc.GetOrder(id);
            if(oldOrder.OrderId==0)
            {
                return false;
            }
            order.OrderId =id;
            bool status = _ordersvc.UpdateOrder(order);
            return status;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteOrder(int id)
        {
            bool status = _ordersvc.DeleteOrder(id);
            return status;
        }



        [HttpGet]
        [Route("Count/{date}")]
        public int GetCountByDate(DateTime date)
        {
            
            Console.WriteLine(date);
            int counts = _ordersvc.GetCountByDate(date);
            return counts;
        }

    }
}
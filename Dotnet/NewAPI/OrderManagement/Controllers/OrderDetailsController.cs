using Transflower.EKrushi.OrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Transflower.EKrushi.OrderManagement.Services;
using Transflower.EKrushi.OrderManagement.Services.Interfaces;

namespace Transflower.EKrushi.OrderManagement.Controllers
{
    [ApiController]
    [Route("api/orderdetails")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderService;
        public OrderDetailsController(IOrderDetailsService orderService)
        {
           _orderService = orderService;
        }

       

        //http://localhost:5057/api/orderdetails/{id} 
        [HttpGet("{id}")]
        public async Task<OrderDetails> GetOrderDetail(int id)
        {
            OrderDetails orderDetail = await _orderService.GetOrderDetail(id);
            return orderDetail;
        }

       
        //http://localhost:5057/api/orderdetails/{id} 
        [HttpDelete("{id}")]
        public async Task<bool> DeleteOrderDetail(int id)
        {
            bool status = await _orderService.Delete(id);
            return status;
        }

        //http://localhost:5057/api/orderdetails/order/{orderId} 
        [HttpGet("order/{orderId}")]
        public async Task<List<OrderDetails>> GetDetails(int orderId)
        {
            List<OrderDetails> orders = await _orderService.GetDetails(orderId);
            return orders;
        }
    }
}
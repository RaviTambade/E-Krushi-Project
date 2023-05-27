using OrderProcessingService.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using OrderProcessingService.Services;
using OrderProcessingService.Services.Interfaces;

namespace OrderProcessingService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _ordersvc;
        public OrderDetailsController(IOrderDetailsService ordersvc)
        {
            _ordersvc = ordersvc;
        } 

        [HttpGet("orderdetails")]
        public async Task<IEnumerable<OrderDetails>> OrderDetails()
        {
            List<OrderDetails> orderDetails = await _ordersvc.OrderDetails();
            return orderDetails;
        }

        [HttpGet("getorderDetails/{id}")]
        public async Task<OrderDetails> OrderDetail(int id)
        {
            OrderDetails orderDetail = await _ordersvc.OrderDetail(id);
            return orderDetail;
        }

        [HttpPost("insert")]
        public async Task<bool> Insert([FromBody] OrderDetails orderDetail)
        {
            bool status = await _ordersvc.Insert(orderDetail);
            return status;
        }

        [HttpPut("update/{id}")]
        public async Task<bool> Update(int id,[FromBody] OrderDetails orderDetail)
        {
            OrderDetails oldOrderDetail = await _ordersvc.OrderDetail(id);
            if(oldOrderDetail.Id==0)
            {
                return false;
            }
            orderDetail.Id =id;
            bool status = await _ordersvc.Update(orderDetail);
            return status;
        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> DeleteOrderDetail(int id)
        {
            bool status = await _ordersvc.Delete(id);
            return status;
        }
    }
}
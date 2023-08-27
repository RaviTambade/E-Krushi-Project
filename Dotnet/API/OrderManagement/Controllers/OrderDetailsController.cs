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

        //http://localhost:5057/api/orderdetails 
        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails()
        {
            List<OrderDetails> orderDetails = await _orderService.GetAllOrderDetails();
            return orderDetails;
        }

        //http://localhost:5057/api/orderdetails/{id} 
        [HttpGet("{id}")]
        public async Task<OrderDetails> GetOrderDetail(int id)
        {
            OrderDetails orderDetail = await _orderService.GetOrderDetail(id);
            return orderDetail;
        }

        //http://localhost:5057/api/orderdetails 
        public async Task<bool> Insert([FromBody] OrderDetails orderDetail)
        {
            bool status = await _orderService.Insert(orderDetail);
            return status;
        }

        //http://localhost:5057/api/orderdetails/{id}
        [HttpPut("{id}")]
        public async Task<bool> Update(int id, [FromBody] OrderDetails orderDetail)
        {
            OrderDetails oldOrderDetail = await _orderService.GetOrderDetail(id);
            if (oldOrderDetail.Id == 0)
            {
                return false;
            }
            orderDetail.Id = id;
            bool status = await _orderService.Update(orderDetail);
            return status;
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
        public async Task<List<OrderHistory>> GetDetails(int orderId)
        {
            List<OrderHistory> orders = await _orderService.GetDetails(orderId);
            return orders;
        }
    }
}
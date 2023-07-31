using OrderProcessingService.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using OrderProcessingService.Services;
using OrderProcessingService.Services.Interfaces;

namespace OrderProcessingService.Controllers
{
    [ApiController]
    [Route("api/orderdetails")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _ordersvc;
        public OrderDetailsController(IOrderDetailsService ordersvc)
        {
            _ordersvc = ordersvc;
        }

        //http://localhost:5057/api/orderdetails 
        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails()
        {
            List<OrderDetails> orderDetails = await _ordersvc.GetAllOrderDetails();
            return orderDetails;
        }

        //http://localhost:5057/api/orderdetails/{id} 
        [HttpGet("{id}")]
        public async Task<OrderDetails> GetOrderDetail(int id)
        {
            OrderDetails orderDetail = await _ordersvc.GetOrderDetail(id);
            return orderDetail;
        }

        //http://localhost:5057/api/orderdetails 
        public async Task<bool> Insert([FromBody] OrderDetails orderDetail)
        {
            bool status = await _ordersvc.Insert(orderDetail);
            return status;
        }

        //http://localhost:5057/api/orderdetails/{id}
        [HttpPut("{id}")]
        public async Task<bool> Update(int id, [FromBody] OrderDetails orderDetail)
        {
            OrderDetails oldOrderDetail = await _ordersvc.GetOrderDetail(id);
            if (oldOrderDetail.Id == 0)
            {
                return false;
            }
            orderDetail.Id = id;
            bool status = await _ordersvc.Update(orderDetail);
            return status;
        }

        //http://localhost:5057/api/orderdetails/{id} 
        [HttpDelete("{id}")]
        public async Task<bool> DeleteOrderDetail(int id)
        {
            bool status = await _ordersvc.Delete(id);
            return status;
        }

        //http://localhost:5057/api/orderdetails/order/{orderId} 
        [HttpGet("order/{orderId}")]
        public async Task<List<OrderHistory>> GetDetails(int orderId)
        {
            List<OrderHistory> orders = await _ordersvc.GetDetails(orderId);
            return orders;
        }
    }
}
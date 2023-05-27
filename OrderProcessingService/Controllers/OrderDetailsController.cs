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
        public IEnumerable<OrderDetails> OrderDetails()
        {
            List<OrderDetails> orderDetails = _ordersvc.OrderDetails();
            return orderDetails;
        }

        [HttpGet("getorderDetails/{id}")]
        public OrderDetails OrderDetail(int id)
        {
            OrderDetails orderDetail = _ordersvc.OrderDetail(id);
            return orderDetail;
        }

        [HttpPost("insertorderdetail")]
        public bool Insert([FromBody] OrderDetails orderDetail)
        {
            bool status =_ordersvc.Insert(orderDetail);
            return status;
        }

        [HttpPut("updateorderdetail/{id}")]
        public bool Update(int id,[FromBody] OrderDetails orderDetail)
        {
            OrderDetails oldOrderDetail = _ordersvc.OrderDetail(id);
            if(oldOrderDetail.OrderDetailsId==0)
            {
                return false;
            }
            orderDetail.OrderDetailsId =id;
            bool status = _ordersvc.Update(orderDetail);
            return status;
        }

        [HttpDelete("deleteorderdetail/{id}")]
        public bool DeleteOrderDetail(int id)
        {
            bool status = _ordersvc.Delete(id);
            return status;
        }
    }
}
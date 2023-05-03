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

        [HttpGet]
        [Route("getallorderdetails")]
        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            List<OrderDetails> orderDetails = _ordersvc.GetAllOrderDetails();
            return orderDetails;
        }

        [HttpGet]
        [Route("getorderDetails/{id}")]
        public OrderDetails GetOrderDetail(int id)
        {
            OrderDetails orderDetail = _ordersvc.GetOrderDetail(id);
            return orderDetail;
        }

        [HttpPost]
        [Route("insertorderdetail")]
        public bool InsertOrderDetail([FromBody] OrderDetails orderDetail)
        {
            bool status =_ordersvc.InsertOrderDetail(orderDetail);
            return status;
        }

        [HttpPut]
        [Route("updateorderdetail/{id}")]
        public bool UpdateOrder(int id,[FromBody] OrderDetails orderDetail)
        {
            OrderDetails oldOrderDetail = _ordersvc.GetOrderDetail(id);
            if(oldOrderDetail.OrderDetailsId==0)
            {
                return false;
            }
            orderDetail.OrderDetailsId =id;
            bool status = _ordersvc.UpdateOrderDetail(orderDetail);
            return status;
        }

        [HttpDelete]
        [Route("deleteorderdetail/{id}")]
        public bool DeleteOrderDetail(int id)
        {
            bool status = _ordersvc.DeleteOrderDetail(id);
            return status;
        }
    }
}
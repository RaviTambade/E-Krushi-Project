using Transflower.EKrushi.OrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Transflower.EKrushi.OrderManagement.Services.Interfaces;
using Transflower.EKrushi.OrderManagement.Helpers;

namespace Transflower.EKrushi.OrderManagement.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
       _orderService = orderService;
        } 

       
        

        

      

        
        

        //http://localhost:5057/api/orders/customerorders
        [HttpGet("customerorders/{customerid}")]          
        public async Task<List<CustomerOrder>> GetOrderDetails(int customerid)
        {
            List<CustomerOrder> customerOrders= await _orderService.GetOrderDetails(customerid);
            return customerOrders;
        }

        [HttpGet("customerorders/orderid/{orderid}")]          
        public CustomerOrder GetOrderDetailsByOrderId(int orderid)
        {
            CustomerOrder customerOrder=  _orderService.GetOrderDetailsByOrderId(orderid);
            return customerOrder;
        }


         
    }
}
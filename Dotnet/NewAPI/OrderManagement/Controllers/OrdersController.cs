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

        [Authorize]  
        //http://localhost:5057/api/orders        
        public async Task<IEnumerable<Order>> Orders()
        {
            List<Order> orders = await _orderService.Orders();
            return orders;
        }

        //http://localhost:5057/api/orders/{id}
        [HttpGet("{id}")]
        public async Task<Order> GetById(int id)
        {
            Order order = await _orderService.GetOrder(id);
            return order;
        }

        [HttpPost("insert")]
        //http://localhost:5057/api/orders 
        public async Task<bool> Insert([FromBody] Order order)
        {
            bool status = await _orderService.Insert(order);
            return status;
        }

        //http://localhost:5057/api/orders/{id}
        [HttpPut("{id}")]
        public async Task<bool> Update(int id,[FromBody] Order order)
        {
            Order oldOrder = await _orderService.GetOrder(id);
            if(oldOrder.Id==0)
            {
                return false;
            }
            order.Id =id;
            bool status = await _orderService.Update(order);
            return status;
        }

        //http://localhost:5057/api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status = await _orderService.Delete(id);
            return status;
        }


        //http://localhost:5057/api/orders/count/{date} 
        [HttpGet("Count/{date}")]                    //This query gives count of order by date
        public async Task<int> GetCountByDate(DateTime date)
        {
            
            Console.WriteLine(date);
            int counts = await _orderService.GetCountByDate(date);
            return counts;
        }

        //http://localhost:5057/api/orders/totalcount                                            
        [HttpGet("totalcount")]                     //This query gives total count of orders
        public async Task<int> TotalCount()
        {
            int totalCounts = await _orderService.TotalCount();
            return totalCounts;
        }

        //http://localhost:5057/api/orders/customer/{id} 
        [HttpGet("customer/{id}")]          
        public async Task<List<Order>> OrderByCustId(int id)
        {
            List<Order> orders = await _orderService.OrderByCustId(id);
            return orders;
        }

        // //http://localhost:5057/api/orders/orderhistory/{custId}
        // [HttpGet("orderhistory/{custId}")]          
        // public async Task<List<OrderHistory>> GetOrderHistory(int custId)
        // {
        //     List<OrderHistory> orders = await _orderService.GetOrderHistory(custId);
        //     return orders;
        // }

        //http://localhost:5057/api/orders/customerorders
        [HttpGet("customerorders/{customerid}")]          
        public async Task<List<CustomerOrder>> GetOrderDetails(int customerid)
        {
            List<CustomerOrder> customerOrders= await _orderService.GetOrderDetails(customerid);
            return customerOrders;
        }

        //http://localhost:5057/api/orders/orderDate/{fromDate}/{toData}
        [HttpGet("orderDate/{fromDate}/{toDate}")] 
        public async Task<IEnumerable<Order>> FilterDate(DateTime fromDate,DateTime toDate)
        {
            List<Order> orders= await _orderService.FilterDate(fromDate,toDate);
            return orders;
        }


         
    }
}
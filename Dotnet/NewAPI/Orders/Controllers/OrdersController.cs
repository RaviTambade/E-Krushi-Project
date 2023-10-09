using Transflower.EKrushi.Orders.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.Orders.Models;

namespace Transflower.EKrushi.Orders.Controllers;

[ApiController]
[Route("/api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet("customer/{customerId}")]
    public async Task<List<CustomerOrder>> GetCustomerOrderDetails(int customerId)
    {
        return await _service.GetCustomerOrderDetails(customerId);
    }

    [HttpGet("details/{orderId}")]
    public async Task<List<OrderDetailModel>> GetOrderDetails(int orderId)
    {
        return await _service.GetOrderDetails(orderId);
    }

    [HttpGet("amount/{orderId}")]
    public async Task<double> GetOrderAmount(int orderId)
    {
        return await _service.GetOrderAmount(orderId);
    }

    [HttpGet("address/{orderId}")]
    public async Task<int> GetAddressIdOfOrder(int orderId)
    {
        return await _service.GetAddressIdOfOrder(orderId);
    }

    [HttpPost]
    public async Task<OrderAmount> CreateOrder(OrderAddModel order)
    {
        return await _service.CreateOrder(order);
    }

    [HttpDelete("{orderId}")]
    public async Task<bool> RemoveOrder(int orderId)
    {
        return await _service.RemoveOrder(orderId);
    }

    [HttpPatch("status")]
    public async Task<bool> UpdateOrderStatus(OrderUpdateModel order)
    {
        return await _service.UpdateOrderStatus(order);
    }
}

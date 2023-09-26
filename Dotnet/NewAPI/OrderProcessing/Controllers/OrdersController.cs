// using OrderProcessing.Models;
using OrderProcessing.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Models;

namespace OrderProcessing.Controllers;

[ApiController]
[Route("/api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
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
}

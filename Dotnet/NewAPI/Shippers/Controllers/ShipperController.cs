using TransFlower.EKrushi.Shippers.Models;
using TransFlower.EKrushi.Shippers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TransFlower.EKrushi.Shippers.Controllers;

[ApiController]
[Route("/api/shippers")]
public class ShippersController : ControllerBase
{
    private readonly IShipperService _service;

    public ShippersController(IShipperService service)
    {
        _service = service;
    }

    [HttpGet("{shipperId}/{status}")]
    public async Task<IEnumerable<ShipperOrder>> GetShipperOrdersByStatus(
        int shipperId,
        string status
    )
    {
        return await _service.GetShipperOrdersByStatus(shipperId, status);
    }

    [HttpGet("orderscount/{shipperId}")]
    public async Task<OrderStatusCount> GetShipperOrdersCount(int shipperId)
    {
        return await _service.GetShipperOrdersCount(shipperId);
    }

    [HttpGet("nearby/{storeId}")]
    public async Task<int> GetNearestShipperId(int storeId)
    {
        return await _service.GetNearestShipperId(storeId);
    }

    [HttpGet("shipperid/{userId}")]
    public async Task<int> GetShipperIdByUserId(int userId)
    {
        return await _service.GetShipperIdByUserId(userId);
    }
}

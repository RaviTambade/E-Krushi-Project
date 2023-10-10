
using TransFlower.EKrushi.Shippers.Models;
using TransFlower.EKrushi.Shippers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TransFlower.EKrushi.Shippers.Controllers;

[ApiController]
[Route("/api/shippers")]
public class ShipperController : ControllerBase
{
    private readonly IShipperService _service;

    public ShipperController(IShipperService service)
    {
        _service = service;
    }
    [HttpGet("{shipperId}/{status}")]

      public async Task<IEnumerable<ShipperOrder>> GetShipperOrdersByStatus(int shipperId, string status)
    {
        return await _service.GetShipperOrdersByStatus(shipperId, status);
    }
    [HttpGet("nearby/{storeId}")]
    public async Task<int> GetNearestShipperId(int storeId)
    {
      return await _service.GetNearestShipperId(storeId);
    }

}
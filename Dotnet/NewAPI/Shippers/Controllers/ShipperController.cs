
using Shippers.Models;
using Shippers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Shippers.Controllers;

[ApiController]
[Route("/api/shippers")]
public class ShipperController : ControllerBase
{
    private readonly IShipperService _service;

    public ShipperController(IShipperService service)
    {
        _service = service;
    }
    [HttpGet("nearby/{storeId}")]
    public async Task<int> GetNearestShipperId(int storeId)
    {
      return await _service.GetNearestShipperId(storeId);
    }

}
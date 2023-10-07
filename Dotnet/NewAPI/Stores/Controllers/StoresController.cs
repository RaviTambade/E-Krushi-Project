using Stores.Models;
using Stores.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Stores.Controllers;

[ApiController]
[Route("/api/stores")]
public class StoresController : ControllerBase
{
    private readonly IStoreService _service;

    public StoresController(IStoreService service)
    {
        _service = service;
    }

    [HttpGet("{storeId}")]
    public async Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId)
    {
        return await _service.GetAllStoreOrders(storeId);
    }

    [HttpGet("nearby/{customerAddressId}")]
    public async Task<int> GetNearestStoreId(int customerAddressId)
    {
        return await _service.GetNearestStoreId(customerAddressId);
    }

    [HttpGet("storedprocedure/{todaysDate}/{storeId}")]
    public OrderSp OrdersStoredProcedure(DateTime todaysDate,int storeId)
    {
        return _service.OrdersStoredProcedure(todaysDate,storeId);
    }

    [HttpGet("user/{storeId}")]
    public async Task<int> GetStoreUserId(int storeId)
    {
        return await _service.GetStoreUserId(storeId);
    }
}

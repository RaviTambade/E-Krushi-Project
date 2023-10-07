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

    [HttpGet("{storeId}/{orderStatus}")]
    public async Task<IEnumerable<StoreOrder>> GetAllStoreOrders(int storeId,string orderStatus)
    {
        return await _service.GetAllStoreOrders(storeId,orderStatus);
    }

    [HttpGet("nearby/{customerAddressId}")]
    public async Task<int> GetNearestStoreId(int customerAddressId)
    {
        return await _service.GetNearestStoreId(customerAddressId);
    }

    

    [HttpGet("user/{storeId}")]
    public async Task<int> GetStoreUserId(int storeId)
    {
        return await _service.GetStoreUserId(storeId);
    }

    [HttpGet("storeId/{userId}")]
    public async Task<int> GetStoreIdByUserId(int userId)
    {
        return await _service.GetStoreIdByUserId(userId);
    }

}

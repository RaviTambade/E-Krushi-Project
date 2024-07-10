using Transflower.EKrushi.Stores.Models;
using Transflower.EKrushi.Stores.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Transflower.EKrushi.Stores.Controllers;

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
    public async Task<IEnumerable<StoreOrder>> GetStoreOrders(int storeId, string orderStatus)
    {
        return await _service.GetStoreOrders(storeId, orderStatus);
    }

    [HttpGet("orderscount/{storeId}")]
    public async Task<OrderStatusCount> GetStoreOrdersCount(int storeId)
    {
        return await _service.GetStoreOrdersCount(storeId);
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

    [HttpGet("storeid/{userId}")]
    public async Task<int> GetStoreIdByUserId(int userId)
    {
        return await _service.GetStoreIdByUserId(userId);
    }

    [HttpGet("name/{storeId}")]
    public async Task<StoreName> GetStoreNameByStoreId(int storeId)
    {
        return await _service.GetStoreNameByStoreId(storeId);
    }
}

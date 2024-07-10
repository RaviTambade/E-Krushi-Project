using Transflower.EKrushi.Suppliers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Transflower.EKrushi.Suppliers.Controllers;

[ApiController]
[Route("/api/suppliers")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _service;

    public SuppliersController(ISupplierService service)
    {
        _service = service;
    }

    [HttpGet("corporate/{supplierId}")]
    public async Task<int> GetCorporateIdOfSupplier(int supplierId)
    {
        return await _service.GetCorporateIdOfSupplier(supplierId);
    }

    [HttpGet("id/{userId}")]
    public async Task<int> GetSupplierId(int userId)
    {
        return await _service.GetSupplierId(userId);
    }
}

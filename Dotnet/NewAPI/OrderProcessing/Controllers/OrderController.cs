
using OrderProcessing.Models;
using OrderProcessing.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace OrderProcessing.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

}
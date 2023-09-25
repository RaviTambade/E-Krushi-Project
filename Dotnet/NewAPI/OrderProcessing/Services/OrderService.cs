
using OrderProcessing.Services.Interfaces;
using OrderProcessing.Repositories.Interfaces;
using OrderProcessing.Models;

namespace OrderProcessing.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }
}
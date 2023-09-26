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

    public async Task<OrderAmount> CreateOrder(OrderAddModel order)
    {
        return await _repository.CreateOrder(order);
    }
      public async Task<bool> RemoveOrder(int orderId)
    {
        return await _repository.RemoveOrder(orderId);
    }
}

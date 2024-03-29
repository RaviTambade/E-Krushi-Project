using Transflower.EKrushi.Orders.Services.Interfaces;
using Transflower.EKrushi.Orders.Repositories.Interfaces;
using Transflower.EKrushi.Orders.Models;

namespace Transflower.EKrushi.Orders.Services;

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

    public async Task<double> GetOrderAmount(int orderId)
    {
        return await _repository.GetOrderAmount(orderId);
    }

    public async Task<List<CustomerOrder>> GetCustomerOrders(int customerId,string orderStatus )
    {
        return await _repository.GetCustomerOrders(customerId,orderStatus);
    }

    public async Task<bool> RemoveOrder(int orderId)
    {
        return await _repository.RemoveOrder(orderId);
    }

    public async Task<List<OrderDetailModel>> GetOrderDetails(int orderId)
    {
        return await _repository.GetOrderDetails(orderId);
    }

    public async Task<int> GetAddressIdOfOrder(int orderId)
    {
        return await _repository.GetAddressIdOfOrder(orderId);
    }

    public async Task<bool> UpdateOrderStatus(OrderUpdateModel order)
    {
        return await _repository.UpdateOrderStatus(order);
    }
}

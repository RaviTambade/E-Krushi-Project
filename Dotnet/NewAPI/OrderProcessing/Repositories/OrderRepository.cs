
using OrderProcessing.Models;
using OrderProcessing.Repositories.Interfaces;
using OrderProcessing.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;


namespace OrderProcessing.Repositories;
public class OrderRepository : IOrderRepository
{ 
    private readonly IConfiguration _configuration;

    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
}
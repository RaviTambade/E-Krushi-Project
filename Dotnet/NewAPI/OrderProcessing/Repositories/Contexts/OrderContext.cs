using OrderProcessing.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderProcessing.Repositories.Contexts;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }

    public OrderContext(DbContextOptions options)
        : base(options)
    {
        Orders = Set<Order>();
        OrderDetails = Set<OrderDetail>();
        Products = Set<Product>();
        ProductDetails = Set<ProductDetail>();
    }
}

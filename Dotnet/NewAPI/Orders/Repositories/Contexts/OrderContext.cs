using Transflower.EKrushi.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Orders.Entities;

namespace Transflower.EKrushi.Orders.Repositories.Contexts;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Store> Stores { get; set; }

    public OrderContext(DbContextOptions options)
        : base(options)
    {
        Orders = Set<Order>();
        OrderDetails = Set<OrderDetail>();
        Products = Set<Product>();
        ProductDetails = Set<ProductDetail>();
        Stores = Set<Store>();
    }
}

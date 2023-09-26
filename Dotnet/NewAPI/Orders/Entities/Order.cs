using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transflower.EKrushi.Orders.Entities;

public class Order
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("orderdate")]
    public DateTime OrderDate { get; set; }

    [Column("shippeddate")]
    public DateTime ShippedDate { get; set; }

    [Column("customerid")]
    public int CustomerId { get; set; }

    [Column("addressid")]
    public int AddressId { get; set; }

    [Column("total")]
    public double Total { get; set; }

    [Column("status")]
    public  string? Status { get; set; }

    public Order()
    {
        OrderDate = DateTime.Now;
        ShippedDate = DateTime.Now.AddDays(7);
    }
}

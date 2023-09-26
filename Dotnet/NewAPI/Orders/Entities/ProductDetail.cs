using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transflower.EKrushi.Orders.Entities;

public class ProductDetail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("productid")]
    public int ProductId { get; set; }

    [Column("unitprice")]
    public double UnitPrice { get; set; }

    [Column("size")]
    public string? Size { get; set; }

    [Column("stockavailable")]
    public int StockAvailable { get; set; }

    [Column("supplierid")]
    public int SupplierId { get; set; }
}

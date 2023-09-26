using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessing.Entities;

public class OrderDetail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("orderid")]
    public int OrderId { get; set; }

    [Column("productdetailsid")]
    public int ProductDetailsId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("discount")]
    public double Discount { get; set; }
}

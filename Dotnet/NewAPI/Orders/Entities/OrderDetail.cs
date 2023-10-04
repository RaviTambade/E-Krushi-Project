using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transflower.EKrushi.Orders.Entities;
[Table("orderdetails")]
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

}

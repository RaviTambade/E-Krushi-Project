using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transflower.EKrushi.Orders.Entities;

[Table("orders")]
public class ShipperOrder
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("orderid")]
    public int OrderId { get; set; }

    [Column("shipperid")]
    public int ShipperId { get; set; }
}

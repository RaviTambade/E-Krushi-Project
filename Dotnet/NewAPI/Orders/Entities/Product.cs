using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transflower.EKrushi.Orders.Entities;
[Table("products")]

public class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    [Column("categoryid")]
    public int CategoryId { get; set; }
}

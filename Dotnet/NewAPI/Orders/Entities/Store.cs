using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Entities;

[Table("stores")]
public class Store
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("userid")]
    public int UserId { get; set; }

    [Column("addressid")]
    public int AddressId { get; set; }
}

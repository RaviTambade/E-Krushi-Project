namespace Transflower.EKrushi.Catalog.Models;

public class Product
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public double Rating { get; set; }
    public double UnitPrice { get; set; }
    public List<string>? size { get; set; }
}

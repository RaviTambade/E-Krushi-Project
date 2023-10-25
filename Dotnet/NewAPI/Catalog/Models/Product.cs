namespace Transflower.EKrushi.Catalog.Models;

public class Product
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public double Rating { get; set; }
    public required IEnumerable<ProductDetail> ProductDetails { get; set; } 
}

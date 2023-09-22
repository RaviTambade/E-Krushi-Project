namespace Transflower.EKrushi.ShoppingCartService.Models;

public class CartItem
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public required string Size { get; set; }
}

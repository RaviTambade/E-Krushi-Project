namespace Transflower.EKrushi.ShoppingCartService.Models
{
    public class Item
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public string? Size { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
   
    }
}

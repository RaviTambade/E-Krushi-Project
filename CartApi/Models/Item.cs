namespace ShoppingCartService.Models
{
    public class Item
    {
        public int ProductId{get; set;}
        public int CartId{get; set;}

        public string? Title{get; set;}

        public string? Image{get; set;}

        public int Quantity{get;set;}

        public double UnitPrice{get; set;}
        
    }
}
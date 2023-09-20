namespace Transflower.EKrushi.ShoppingCartService.Models
{
    public class Cart
    {
        public int CartId{get; set;}
        public List<Item> Items{get; set;}
        public Cart()
        {
            Items = new List<Item>();
        }
        public double TotalAmount
        {
            get { return Items.Sum(p => p.TotalPrice); }
        }   
    }
}
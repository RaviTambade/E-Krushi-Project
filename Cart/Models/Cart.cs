namespace CartService.Models
{
    public class Cart
    {
        public int CartId{get; set;}

        public List<Item> Items{get; set;}

        public Cart()
        {
            this.Items = new List<Item>();
        }
        
    }
}
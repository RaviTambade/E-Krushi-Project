namespace ShoppingCartService.Models
{
    public class Cart
    {
        public int CartId{get; set;}

        public List<Item> Items{get; set;}

        public Cart()
        {
            this.Items = new List<Item>();
        }

        public double TotalAmount
       {
            get { return Items.Sum(p => p.Quantity * p.UnitPrice); }
       }   
    }
}
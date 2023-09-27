using Transflower.EKrushi.ShoppingCartService.Models;

namespace Transflower.EKrushi.ShoppingCartService.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Item>> GetCartItems(int customerId);
        Task<bool> RemoveItem(int cartItemId);
        Task<bool> UpdateItemQuantity(int cartItemId, int quantity);
        Task<bool> AddItem(CartItem item);
        Task<bool> IsProductInCart(CartItem item);
        Task<bool> RemoveAllCartItems(int cartId);

        // Task<Cart> GetAll(int custid);
        // Task<bool> AddItem(Item item);

        // Task<bool> Update(Item item);
        // Task<int> GetCartId(int custId);


        // Task<List<Item>> GetCartDetails(int custId);

        // Task<bool> CreateOrder(int CartId);
    }
}

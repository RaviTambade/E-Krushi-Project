using Transflower.EKrushi.ShoppingCartService.Models;

namespace Transflower.EKrushi.ShoppingCartService.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Item>> GetCartItems(int customerId);
        Task<bool> UpdateItemQuantity(int cartItemId, int quantity);
        // Task<Cart> GetAll(int custid);
        // Task<bool> AddItem(Item item);

        // Task<bool> Update(Item item);
        // Task<bool> RemoveItem(int cartItemId);
        // Task<int> GetCartId(int custId);


        // Task<List<Item>> GetCartDetails(int custId);

        // Task<bool> CreateOrder(int CartId);
    }
}

using ShoppingCartService.Models;

namespace ShoppingCartService.Repositories.Interfaces{

    public interface ICartRepository{

        Task<Cart> GetAll(int custid);
        Task<Cart> GetCart(int id);
        Task<bool> AddItem(Item item);

        // Task<bool> UpdateItem(int CartId,Item item);
        // Task<bool> RemoveItem(int CartId,Item item);    
        Task<int> GetCartId(int custId);

        Task<List<Item>> GetCartDetails(int custId);
        
    }
}
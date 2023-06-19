using ShoppingCartService.Models;

namespace ShoppingCartService.Repositories.Interfaces{

    public interface ICartRepository{

        Task<Cart> GetAll(int custid);
        Task<Cart> GetCart(int id);
        Task<bool> AddItem(Item item);

        Task<bool> Update(Item item);
        Task<bool> RemoveItem(int productId);    
        Task<int> GetCartId(int custId);

        Task<Item> Get(int id);

        Task<List<Item>> GetCartDetails(int custId);
        
    }
}
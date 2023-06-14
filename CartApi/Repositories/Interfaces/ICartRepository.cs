using ShoppingCartService.Models;

namespace ShoppingCartService.Repositories.Interfaces{

    public interface ICartRepository{

        // Task<List<Cart>> GetAll();
        Task<Cart> GetCart(int id);
        Task<bool> AddItem(Item item);

        // Task<bool> UpdateItem(int CartId,Item item);
        // Task<bool> RemoveItem(int CartId,Item item);    

    }
}
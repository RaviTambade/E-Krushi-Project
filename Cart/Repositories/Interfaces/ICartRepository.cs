using CartService.Models;

namespace CartService.Repositories.Interfaces{

    public interface ICartRepository{

        Task<List<Cart> GetAllCarts();

        Task<Cart> GetCart();

        

    }
}
using ShoppingCartService.Models;
using ShoppingCartService.Repositories.Interfaces;
using ShoppingCartService.Services.Interfaces;

namespace ShoppingCartService.Services;
public class CartService : ICartService
{
    private readonly ICartRepository _repo;
    public CartService(ICartRepository repo)
    {
        this._repo = repo;
    }

    public async Task<bool> AddItem(int cartId, Item item)
    {
        return await _repo.AddItem(cartId, item);
    }

    public async Task<Cart> GetCart(int id)
    {
        return await _repo.GetCart(id);
    }
}
using Transflower.EKrushi.ShoppingCartService.Models;
using Transflower.EKrushi.ShoppingCartService.Repositories.Interfaces;
using Transflower.EKrushi.ShoppingCartService.Interfaces;

namespace ShoppingCartService.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _repository;

    public CartService(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Item>> GetCartItems(int customerId)
    {
        return await _repository.GetCartItems(customerId);
    }

    public async Task<bool> UpdateItemQuantity(int cartItemId, int quantity)
    {
        if (quantity < 1 || quantity > 10)
        {
            return false;
        }
        return await _repository.UpdateItemQuantity(cartItemId, quantity);
    }

    public async Task<bool> RemoveItem(int cartItemId)
    {
        return await _repository.RemoveItem(cartItemId);
    }

    public async Task<bool> AddItem(CartItem item)
    {
        return await _repository.AddItem(item);
    }
       public async Task<bool> IsProductInCart (CartItem item)
        {
            return await _repository.IsProductInCart(item);
        }

  




    // public async Task<int> GetCartId(int custId)
    // {
    //     return await _repository.GetCartId(custId);
    // }

    // public async Task<List<Item>> GetCartDetails(int custId)
    // {
    //     return await _repository.GetCartDetails(custId);
    // }



    // public async Task<bool> Update(Item item)
    // {
    //     return await _repository.Update(item);
    // }

    // public async Task<bool> CreateOrder(int CartId)
    // {
    //     return await _repository.CreateOrder(CartId);
    // }
}

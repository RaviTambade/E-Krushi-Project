using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.ShoppingCartService.Models;
using Transflower.EKrushi.ShoppingCartService.Helpers;

namespace Transflower.EKrushi.ShoppingCartService.Controllers;

[ApiController]
[Route("/api/carts")]
public class CartsController : ControllerBase
{
    private const int MaxAllowedQuantity = 10;

    [HttpGet]
    public async Task<Cart> GetCart()
    {
        Cart cart =
            await HttpContext.Session.GetObjectFromJson<Cart>(SessionKeys.Cart) ?? new Cart();
        return cart;
    }

    [HttpPost]
    public async Task<bool> AddItemToCart([FromBody] Item item)
    {
        var cart = await HttpContext.Session.GetObjectFromJson<Cart>(SessionKeys.Cart) ?? new Cart();
        cart.Items.Add(item);
        await HttpContext.Session.SetObjectAsJson(SessionKeys.Cart, cart);
        return true;
    }

    [HttpPut("items/{productDetailsId}/quantity/{quantity}")]
    public async Task<bool> UpdateItemQuantity(int productDetailsId, int quantity)
    {
        if (quantity > MaxAllowedQuantity)
        {
            return false;
        }

        var cart = await HttpContext.Session.GetObjectFromJson<Cart>(SessionKeys.Cart);
        if (cart is null)
        {
            return false;
        }

        var item = cart.Items.FirstOrDefault(i => i.ProductDetailsId == productDetailsId);
        if (item is null)
        {
            return false;
        }

        item.Quantity = quantity;
        await HttpContext.Session.SetObjectAsJson(SessionKeys.Cart, cart);
        return true;
    }

    [HttpDelete]
    [Route("items/remove/{productDetailsId}")]
    public async Task<bool> RemoveItem(int productDetailsId)
    {
        var cart = await HttpContext.Session.GetObjectFromJson<Cart>(SessionKeys.Cart);
        if (cart is null)
        {
            return false;
        }

        var item = cart.Items.FirstOrDefault(i => i.ProductDetailsId == productDetailsId);
        if (item is null)
        {
            return false;
        }
        bool status = cart.Items.Remove(item);
        await HttpContext.Session.SetObjectAsJson(SessionKeys.Cart, cart);
        return status;
    }
    [HttpDelete]
    [Route("items/removeall")]
    public async Task<bool> RemoveAllCartItems()
    {
        Cart cart = new();
        await HttpContext.Session.SetObjectAsJson(SessionKeys.Cart, cart);
        return true;

    }

    [HttpGet]
    [Route("items/product/ispresent/{productDetailsId}")]
    public async Task<bool> IsProductInCart(int productDetailsId)
    {
        var cart = await HttpContext.Session.GetObjectFromJson<Cart>(SessionKeys.Cart);
        if (cart is null)
        {
            return false;
        }

        var item = cart.Items.FirstOrDefault(i => i.ProductDetailsId == productDetailsId);
        if (item is null)
        {
            return false;
        }
        return true;
    }
}

// private readonly ICartService _service;

// public CartsController(ICartService service)
// {
//     _service = service;
// }

// [HttpGet("customer/{customerId}")]
// public async Task<List<Item>> GetCartItems(int customerId)
// {
//     return await _service.GetCartItems(customerId);
// }

// [HttpPost]
// public async Task<bool> AddItem([FromBody] CartItem item)
// {
//     return await _service.AddItem(item);
// }

// [HttpPut("item/{cartItemId}/quantity/{quantity}")]
// public async Task<bool> UpdateItemQuantity(int cartItemId, int quantity)
// {
//     return await _service.UpdateItemQuantity(cartItemId, quantity);
// }

// [HttpDelete]
// [Route("remove/{cartItemId}")]
// public async Task<bool> RemoveItem(int cartItemId)
// {
//     return await _service.RemoveItem(cartItemId);
// }

// [HttpDelete]
// [Route("removeall/{customerId}")]
// public async Task<bool> RemoveAllCartItems(int customerId)
// {
//     return await _service.RemoveAllCartItems(customerId);
// }

// [HttpPost]
// [Route("product/present")]
// public async Task<bool> IsProductInCart(CartItem item)
// {
//     return await _service.IsProductInCart(item);
// }

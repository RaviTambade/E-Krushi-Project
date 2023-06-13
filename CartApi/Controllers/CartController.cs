using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using ShoppingCartService.Models;
using ShoppingCartService.Services.Interfaces;

namespace ShoppingCartService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CartController : ControllerBase
    {
        
        private readonly ICartService _cartSrv;
        public CartController( ICartService cartService)
        {
            _cartSrv = cartService;       
        }

        [HttpGet("getcartdetails/{id}")]
        public async Task<Cart> GetCart(int id)
        {
            Cart cart = await _cartSrv.GetCart(id);
            Console.WriteLine(id);
            return cart;
        }

        [HttpPost]
        [Route("addtocart/{id}")]
        public async Task<bool> AddItem(int id, Item item)
        {
            Cart cart = await _cartSrv.GetCart(id);
            if (cart == null)
            {
                cart = await _cartSrv.GetCart(id);
                cart.Items.Add(item);    
            }
            else
            {
                cart.Items.Add(item);
            }
            bool status = await _cartSrv.AddItem(cart.CartId, item);
            return status;
        }
    }
}
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

        [HttpGet("getall/{id}")]
        public async Task<List<Item>> GetAll(int id)
        {
            List<Item> items = await _cartSrv.GetAll(id);
            Console.WriteLine(id);
            return items;
        }

        [HttpGet("getcartdetails/{id}")]
        public async Task<Cart> GetCart(int id)
        {
            Cart cart = await _cartSrv.GetCart(id);
            Console.WriteLine(id);
            return cart;
        }

        [HttpPost]
        [Route("addtocart")]

        public async Task<bool> AddItem([FromBody] Item item)
        {
            bool status = await _cartSrv.AddItem( item);

            return status;
        }
    }
}
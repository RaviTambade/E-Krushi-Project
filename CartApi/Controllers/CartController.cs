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
        private readonly ILogger<CartController> _logger;
        public CartController(ILogger<CartController> logger, ICartService cartService)
        {
            _cartSrv = cartService;
            _logger = logger;
            
        }




        // [HttpPost]
        // [Route("addtocart/{id}")]
        // public async Task<bool> AddToCart(int id, Item item)
        // {
        //     if (cart == null)
        //     {
        //         cart = await _cartSrv.GetCart(id);
        //         cart.Items.Add(item);
        //         _logger.LogInformation($" item is added to cart " + id + " First it is fetched from database");

        //     }
        //     else
        //     {
        //         cart.Items.Add(item);
        //         _logger.LogInformation($" item is added to cart " + id);
        //     }


        //     bool status = await _cartSrv.AddItem(cart.CartId, item);
        //     if (status)
        //     {
        //         await _distributedCache.RemoveAsync(cacheKey);
        //     }
        //     return status;
        // }
    }
}
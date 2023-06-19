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

        [HttpGet("getall/{custId}")]
        public async Task<Cart> GetAll(int custId)
        {
           Cart items = await _cartSrv.GetAll(custId);
            Console.WriteLine(custId);
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


        [HttpGet("getcartId/{custId}")]
        public async Task<int> GetCartId(int custId)
        {
            int cartId = await _cartSrv.GetCartId(custId);
            return cartId;
        }

        [HttpGet("getcart/{custId}")]
        public async Task<List<Item>> GetCartDetails(int custId)
        {
            Console.WriteLine(custId);
            List<Item> items = await _cartSrv.GetCartDetails(custId);
            return items;
        }

        [HttpDelete]
        [Route("remove/{productId}")]

        public async Task<bool> RemoveItem(int productId)
        {
            bool status = await _cartSrv.RemoveItem(productId);

            return status;
        }    

        [HttpPut]
        [Route("update")]

        public async Task<bool> Update(Item item)
        {
            bool status = await _cartSrv.Update(item);

            return status;
        }  
    }
}
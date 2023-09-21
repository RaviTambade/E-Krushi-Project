using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Transflower.EKrushi.ShoppingCartService.Models;
using Transflower.EKrushi.ShoppingCartService.Interfaces;

namespace Transflower.EKrushi.ShoppingCartService.Controllers
{
    [ApiController]
    [Route("/api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("customer/{id}")]
        public async Task<List<Item>> GetCartItems(int id)
        {
            return await _cartService.GetCartItems(id);
        }

         [HttpPut("item/{cartItemId}/quantity/{quantity}")]
        public async Task<bool> UpdateItemQuantity(int cartItemId,int quantity)
        {
            return await _cartService.UpdateItemQuantity(cartItemId,quantity);
        }

        // [HttpGet("getall/{custId}")]
        // public async Task<Cart> GetAll(int custId)
        // {
        //    Cart items = await _cartService.GetAll(custId);
        //     Console.WriteLine(custId);
        //     return items;
        // }


        //these method is used for get cart details by id.



        //  //this method is used for add item into cart
        // [HttpPost]
        // [Route("addtocart")]

        // public async Task<bool> AddItem([FromBody] Item item)
        // {
        //     bool status = await _cartService.AddItem( item);

        //     return status;
        // }


        // [HttpGet("getcartId/{custId}")]
        // public async Task<int> GetCartId(int custId)
        // {
        //     int cartId = await _cartService.GetCartId(custId);
        //     return cartId;
        // }

        // [HttpGet("getcart/{custId}")]
        // public async Task<List<Item>> GetCartDetails(int custId)
        // {
        //     Console.WriteLine(custId);
        //     List<Item> items = await _cartService.GetCartDetails(custId);
        //     return items;
        // }

        // [HttpDelete]
        // [Route("remove/{cartItemId}")]

        // public async Task<bool> RemoveItem(int cartItemId)
        // {
        //     bool status = await _cartService.RemoveItem(cartItemId);

        //     return status;
        // }

       


        // [HttpGet("createorder/{CartId}")]
        // public async Task<bool> CreateOrder( int CartId)
        // {
        //     return await _cartService.CreateOrder(CartId);
        // }
    }
}

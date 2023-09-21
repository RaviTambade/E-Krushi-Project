using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.ShoppingCartService.Models;
using Transflower.EKrushi.ShoppingCartService.Interfaces;

namespace Transflower.EKrushi.ShoppingCartService.Controllers
{
    [ApiController]
    [Route("/api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("customer/{id}")]
        public async Task<List<Item>> GetCartItems(int id)
        {
            return await _service.GetCartItems(id);
        }

        [HttpPost]
        public async Task<bool> AddItem([FromBody] CartItem item)
        {
            return await _service.AddItem(item);
        }

        [HttpPut("item/{cartItemId}/quantity/{quantity}")]
        public async Task<bool> UpdateItemQuantity(int cartItemId, int quantity)
        {
            return await _service.UpdateItemQuantity(cartItemId, quantity);
        }

        [HttpDelete]
        [Route("remove/{cartItemId}")]
        public async Task<bool> RemoveItem(int cartItemId)
        {
            return await _service.RemoveItem(cartItemId);
        }

        [HttpPost]
        [Route("product/present")]
        public async Task<bool> IsProductInCart (CartItem item)
        {
            return await _service.IsProductInCart(item);
        }

        // [HttpGet("getall/{custId}")]
        // public async Task<Cart> GetAll(int custId)
        // {
        //    Cart items = await _service.GetAll(custId);
        //     Console.WriteLine(custId);
        //     return items;
        // }


        //these method is used for get cart details by id.



        //  //this method is used for add item into cart
        // [HttpPost]
        // [Route("addtocart")]




        // [HttpGet("getcartId/{custId}")]
        // public async Task<int> GetCartId(int custId)
        // {
        //     int cartId = await _service.GetCartId(custId);
        //     return cartId;
        // }

        // [HttpGet("getcart/{custId}")]
        // public async Task<List<Item>> GetCartDetails(int custId)
        // {
        //     Console.WriteLine(custId);
        //     List<Item> items = await _service.GetCartDetails(custId);
        //     return items;
        // }






        // [HttpGet("createorder/{CartId}")]
        // public async Task<bool> CreateOrder( int CartId)
        // {
        //     return await _service.CreateOrder(CartId);
        // }
    }
}

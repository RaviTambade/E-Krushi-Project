using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.ShoppingCartService.Models;
using Transflower.EKrushi.ShoppingCartService.Interfaces;

namespace Transflower.EKrushi.ShoppingCartService.Controllers
{
    [ApiController]
    [Route("/api/carts")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _service;

        public CartsController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<List<Item>> GetCartItems(int customerId)
        {
            return await _service.GetCartItems(customerId);
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

        [HttpDelete]
        [Route("removeall/{customerId}")]
        public async Task<bool> RemoveAllCartItems(int customerId)
        {
            return await _service.RemoveAllCartItems(customerId);
        }

        [HttpPost]
        [Route("product/present")]
        public async Task<bool> IsProductInCart(CartItem item)
        {
            return await _service.IsProductInCart(item);
        }
    }
}

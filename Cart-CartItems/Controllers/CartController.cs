using Cart_CartItems.Commands.CartCommands;
using Cart_CartItems.DataAccess;
using Cart_CartItems.Models;
using Cart_CartItems.Models.DTO;
using Cart_CartItems.Query.CartQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart_CartItems.Controllers
{
    [EnableCors("cart")]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cartService;

        private readonly IMediator _mediator;

        public CartController(ICart cartService, IMediator mediator)
        {
            _cartService = cartService;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddToCart(int userId, GetProductIdDto request)
        {
            try
            {
                var cart = await _mediator.Send(new AddToCartCommand(userId,request));
                return Ok(new
                {
                    cart = cart,
                    message = "Item added to cart successfully."
                });
            }
            //catch (NotFoundException ex)
            //{
            //    return NotFound(new { code = "NotFound", message = ex.Message });
            //}
            catch (Exception ex)
            {
                return StatusCode(500, new { code = "ServerError", message = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var cart = await _mediator.Send(new GetAllCartDetailsQuery()) ;
            return Ok(cart);
        }

        [HttpGet]
        [Route("getCartByUserId/{userId}")]
        public async Task<IActionResult> GetCartByUserId(int userId)
        {
            var cart = await _mediator.Send(new GetCartByUserIdQuery(userId));
            return Ok(cart);
        }

        [HttpPut]
        [Route("updateCart/{userid}")]
        public async Task<IActionResult> UpdateCart(int userid,Cart cart)
        {
            var updateCart = await _mediator.Send(new UpdateCartCommand(userid,cart));
            return StatusCode(201, new {Message= updateCart});
        }

        [HttpDelete]
        [Route("deleteCartItem/{userid}")]
        public async Task<IActionResult> DeleteCartItem(int userid)
        {
            var updateCart = await _mediator.Send(new DeleteCartItemsCommand(userid));
            return StatusCode(201);
        }
    }
}

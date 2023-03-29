using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Commands;
using Orders.Models.DTOs;
using Orders.Query;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("placeOrder")]
        public async Task<IActionResult> PlaceOrder(OrderRequestDto placeOrder)
        {
            var response = await _mediator.Send(new AddOrderCommand(placeOrder));
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult>GetOrders()
        {
            var order = await _mediator.Send(new GetAllOrderQuery());
            return Ok(order); 
        }

        //[HttpDelete("{orderId}")] 
        //public async Task<ActionResult>DeleteOrderById(int orderId)
        //{
        //    await _mediator.Send(new DeleteOrderCommand(orderId));
        //    return StatusCode(200); 
        //}

    }
}

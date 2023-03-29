using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentDetails_Mongo.Commands;
using PaymentDetails_Mongo.Models;

namespace PaymentDetails_Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddPayment")]
        public async Task<ActionResult> Post([FromBody] Payments payment)
        {
            await _mediator.Send(new AddPaymentCommand(payment));
            return StatusCode(201);
        }
    }
}

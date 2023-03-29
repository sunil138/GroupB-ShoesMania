using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_UAuthentication.Command.AuthCommands;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.Controllers
{
    [EnableCors("user")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto newUser)
        {
            var saveUser = await _mediator.Send(new RegisterRequestCommand(newUser));
            //return Ok(saveUser);
            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO loginRequest)
        {
            var result = await _mediator.Send(new LoginRequestCommand(loginRequest));

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            var result = await _mediator.Send(new ForgotPasswordCommand(forgotPasswordDTO));

            return Ok(result);
            //return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto resetPassword)
        {
            var result = await _mediator.Send(new ResetPasswordCommand(resetPassword));

            //return Ok(result);
            return StatusCode(201); 
        }
    }
}

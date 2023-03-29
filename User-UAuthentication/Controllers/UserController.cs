using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using User_UAuthentication.Command.UserCommands;
using User_UAuthentication.Models.DTO;
using User_UAuthentication.Query.UserQuery;

namespace User_UAuthentication.Controllers
{
    [EnableCors("user")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _mediator.Send(new GetAllUsersQuery());
            return Ok(user);
        }

        [HttpGet]
        [Route("getUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [HttpPut]
        [Route("updateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UserDto user)
        {
            await _mediator.Send(new UpdateUserCommand(user));
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return StatusCode(200);
        }
    }
}

using MediatR;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.Command.AuthCommands
{
    public record RegisterRequestCommand(UserRegisterDto newUser):IRequest<string>
    {
    }
}

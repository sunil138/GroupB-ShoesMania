using MediatR;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.Command.UserCommands
{
    public record UpdateUserCommand(UserDto user): IRequest<string>
    {
    }
}

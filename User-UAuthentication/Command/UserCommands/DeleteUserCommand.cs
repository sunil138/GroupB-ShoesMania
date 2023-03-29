using MediatR;

namespace User_UAuthentication.Command.UserCommands
{
    public record DeleteUserCommand(int id) : IRequest<string>
    {
    }
}

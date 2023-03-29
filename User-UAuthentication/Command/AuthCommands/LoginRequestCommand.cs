using MediatR;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.Command.AuthCommands
{
    public record LoginRequestCommand(UserLoginRequestDTO requestUser):IRequest<AuthResultsDto>
    {
    }
}

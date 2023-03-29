using MediatR;
using User_UAuthentication.Command.AuthCommands;
using User_UAuthentication.DataAccess;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.Handler.AuthHandlers
{
    public class LoginRequestHandler : IRequestHandler<LoginRequestCommand, AuthResultsDto>
    {
        private readonly IAuth _auth;

        public LoginRequestHandler(IAuth auth)
        {
            _auth = auth;
        }

        public Task<AuthResultsDto> Handle(LoginRequestCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_auth.login(request.requestUser));
        }
    }
}

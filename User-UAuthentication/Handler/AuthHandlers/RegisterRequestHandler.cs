using MediatR;
using User_UAuthentication.Command.AuthCommands;
using User_UAuthentication.DataAccess;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.Handler.AuthHandlers
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequestCommand, string>
    {
        private readonly IAuth _auth;

        public RegisterRequestHandler(IAuth auth)
        {
            _auth = auth;
        }

       

        Task<string> IRequestHandler<RegisterRequestCommand, string>.Handle(RegisterRequestCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_auth.register(request.newUser));
        }
    }
}

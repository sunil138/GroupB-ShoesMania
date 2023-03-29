using MediatR;
using User_UAuthentication.Command.AuthCommands;
using User_UAuthentication.DataAccess;

namespace User_UAuthentication.Handler.AuthHandlers
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly IAuth _auth;

        public ForgotPasswordHandler(IAuth auth)
        {
            _auth = auth;
        }

        public Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_auth.forgotPassword(request.forgotPasswordDTO));
        }
    }
}

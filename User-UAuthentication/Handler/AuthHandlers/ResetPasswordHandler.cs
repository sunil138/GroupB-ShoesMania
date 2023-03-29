using MediatR;
using User_UAuthentication.Command.AuthCommands;
using User_UAuthentication.DataAccess;

namespace User_UAuthentication.Handler.AuthHandlers
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, string>
    {
        private readonly IAuth _auth;

        public ResetPasswordHandler(IAuth auth)
        {
            _auth = auth;
        }

        public Task<string> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_auth.resetPassword(request.resetPassword));
        }
    }
}

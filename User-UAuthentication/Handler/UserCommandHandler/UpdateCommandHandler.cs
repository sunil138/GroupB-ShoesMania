using MediatR;
using User_UAuthentication.Command.UserCommands;
using User_UAuthentication.DataAccess;

namespace User_UAuthentication.Handler.UserCommandHandler
{
    public class UpdateCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IUser _user;
        public UpdateCommandHandler(IUser user)
        {
            _user = user;
        }

        public Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user.UpdateUser(request.user));
        }
    }
    
}

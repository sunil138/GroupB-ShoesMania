using MediatR;
using User_UAuthentication.Command.UserCommands;
using User_UAuthentication.DataAccess;

namespace User_UAuthentication.Handler.UserCommandHandler
{
    public class DeleteCommandHandler:IRequestHandler<DeleteUserCommand,string>
    {
        private readonly IUser _user;
        public DeleteCommandHandler(IUser user)
        {
            _user = user;
        }

        public Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user.DeleteUser(request.id));
        }
    }
    
}

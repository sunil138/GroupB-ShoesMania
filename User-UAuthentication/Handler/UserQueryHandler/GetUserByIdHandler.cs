using MediatR;
using User_UAuthentication.DataAccess;
using User_UAuthentication.Models;
using User_UAuthentication.Query.UserQuery;

namespace User_UAuthentication.Handler.UserQueryHandler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUser _user;

        public GetUserByIdHandler(IUser user)
        {
            _user = user;
        }

        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user.GetUserById(request.id));
        }
    }
}

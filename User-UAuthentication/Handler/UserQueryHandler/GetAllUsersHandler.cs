using MediatR;
using User_UAuthentication.DataAccess;
using User_UAuthentication.Models;
using User_UAuthentication.Query.UserQuery;

namespace User_UAuthentication.Handler.UserQueryHandler
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUser _user;

        public GetAllUsersHandler(IUser user)
        {
            _user = user;
        }

        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user.GetAllUsers());
        }
    }
}

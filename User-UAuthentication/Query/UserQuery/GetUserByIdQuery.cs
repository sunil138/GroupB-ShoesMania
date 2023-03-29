using MediatR;
using User_UAuthentication.Models;

namespace User_UAuthentication.Query.UserQuery
{
    public record GetUserByIdQuery(int id):IRequest<User>
    {
    }
}

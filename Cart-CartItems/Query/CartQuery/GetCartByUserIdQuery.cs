using Cart_CartItems.Models;
using MediatR;

namespace Cart_CartItems.Query.CartQuery
{
    public record GetCartByUserIdQuery(int userId):IRequest<Cart>
    {
    }
}

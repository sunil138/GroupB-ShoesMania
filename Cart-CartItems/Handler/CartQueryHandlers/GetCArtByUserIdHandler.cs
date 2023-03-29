using Cart_CartItems.DataAccess;
using Cart_CartItems.Models;
using Cart_CartItems.Query.CartQuery;
using MediatR;

namespace Cart_CartItems.Handler.CartQueryHandlers
{
    public class GetCArtByUserIdHandler : IRequestHandler<GetCartByUserIdQuery, Cart>
    {
        private readonly ICart _cart;

        public GetCArtByUserIdHandler(ICart cart)
        {
            _cart = cart;
        }

        public Task<Cart> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _cart.GetCartByUserId(request.userId);
        }
    }
}

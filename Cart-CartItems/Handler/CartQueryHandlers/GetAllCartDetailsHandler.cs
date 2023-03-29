using Cart_CartItems.DataAccess;
using Cart_CartItems.Models;
using Cart_CartItems.Query.CartQuery;
using MediatR;

namespace Cart_CartItems.Handler.CartQueryHandlers
{
    public class GetAllCartDetailsHandler : IRequestHandler<GetAllCartDetailsQuery, List<Cart>>
    {
        private readonly ICart _cart;

        public GetAllCartDetailsHandler(ICart cart)
        {
            _cart = cart;
        }

        public Task<List<Cart>> Handle(GetAllCartDetailsQuery request, CancellationToken cancellationToken)
        {
            return _cart.GetAllCart();
        }
    }
}

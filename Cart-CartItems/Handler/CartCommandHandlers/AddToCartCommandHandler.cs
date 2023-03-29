using Cart_CartItems.Commands.CartCommands;
using Cart_CartItems.DataAccess;
using Cart_CartItems.Models;
using MediatR;

namespace Cart_CartItems.Handler.CartCommandHandlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Cart>
    {

        private readonly ICart _cartService;

        public AddToCartCommandHandler(ICart cart)
        {
            _cartService= cart;
        }
        public Task<Cart> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
           return _cartService.AddToCart(request.userId,request.productRequest);
        }
    }
}

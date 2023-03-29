using Cart_CartItems.Commands.CartCommands;
using Cart_CartItems.DataAccess;
using MediatR;

namespace Cart_CartItems.Handler.CartCommandHandlers
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, bool>
    {
        private readonly ICart _cart;

        public UpdateCartCommandHandler(ICart cart)
        {
            _cart = cart;
        }

        public Task<bool> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            return _cart.updateCart(request.userId,request.cart);
        }

        //public Task<string> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        //{
        //   return Task.FromResult(_cart.updateCart(request.cart));
        //}
    }
}

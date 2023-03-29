using Cart_CartItems.Commands.CartCommands;
using Cart_CartItems.DataAccess;
using MediatR;

namespace Cart_CartItems.Handler.CartCommandHandlers
{
    public class DeletCartItemHandler : IRequestHandler<DeleteCartItemsCommand, string>
    {
        private readonly ICart _cart;

        public DeletCartItemHandler(ICart cart)
        {
            _cart = cart;
        }

        public Task<string> Handle(DeleteCartItemsCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_cart.RemoveCartItems(request.id));
        }
    }
}

using MediatR;

namespace Cart_CartItems.Commands.CartCommands
{
    public record DeleteCartItemsCommand(int id):IRequest<string>
    {
    }
}

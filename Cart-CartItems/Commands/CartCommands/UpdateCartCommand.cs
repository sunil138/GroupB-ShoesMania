using Cart_CartItems.Models;
using MediatR;

namespace Cart_CartItems.Commands.CartCommands
{
    public record UpdateCartCommand(int userId,Cart cart):IRequest<bool>
    {
    }
}

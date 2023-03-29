using Cart_CartItems.Models;
using Cart_CartItems.Models.DTO;
using MediatR;

namespace Cart_CartItems.Commands.CartCommands
{
    public record AddToCartCommand(int userId, GetProductIdDto productRequest):IRequest<Cart>
    {
    }
}

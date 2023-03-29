using MediatR;
using Orders.Models.DTOs;

namespace Orders.Commands
{
    public record AddOrderCommand(OrderRequestDto placeOrder):IRequest<OrderPlacedResponseDto>
    {
    }
}

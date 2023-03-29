using MediatR;

namespace Orders.Commands
{
    public record DeleteOrderCommand(int orderId):IRequest<string>; 
 
}

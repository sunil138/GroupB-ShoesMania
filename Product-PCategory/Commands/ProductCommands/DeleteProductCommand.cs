using MediatR;

namespace Product_PCategory.Commands.ProductCommands
{
    public record DeleteProductCommand(int id):IRequest<string>
    {
    }
}

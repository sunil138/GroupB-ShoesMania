using MediatR;
using Product_PCategory.Models;
using Product_PCategory.Models.DTO;

namespace Product_PCategory.Commands.ProductCommands
{
    public record UpdateProductCommand(ProductRequestDto updateProduct):IRequest<string>
    {
    }
}

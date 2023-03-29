using MediatR;
using Product_PCategory.Models;
using Product_PCategory.Models.DTO;

namespace Product_PCategory.Commands.ProductCommands
{
    public record AddProductCommand(ProductRequestDto newProduct):IRequest<string>
    {
    }
}

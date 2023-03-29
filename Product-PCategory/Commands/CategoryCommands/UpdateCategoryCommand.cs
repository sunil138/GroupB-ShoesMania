using MediatR;
using Product_PCategory.Models;

namespace Product_PCategory.Commands.CategoryCommands
{
    public record UpdateCategoryCommand(ProductCategory updateCategory):IRequest<string>
    {
    }
}

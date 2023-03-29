using MediatR;
using Product_PCategory.Models;

namespace Product_PCategory.Commands.CategoryCommands
{
    public record AddCategoryCommand(ProductCategory newCategory):IRequest<string>
    {
    }
}

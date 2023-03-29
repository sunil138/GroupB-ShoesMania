using MediatR;

namespace Product_PCategory.Commands.CategoryCommands
{
    public record DeleteCategoryCommand(int id):IRequest<string>
    {
    }
}

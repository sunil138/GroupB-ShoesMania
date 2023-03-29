using MediatR;
using Product_PCategory.Commands.CategoryCommands;
using Product_PCategory.DataAccess;

namespace Product_PCategory.Handler.CategoryHandler
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCategoryCommand, string>
    {
        private readonly ICategory _category;

        public DeleteCommandHandler(ICategory category)
        {
            _category= category;
        }
        public Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_category.DeleteCategory(request.id));
        }
    }
}

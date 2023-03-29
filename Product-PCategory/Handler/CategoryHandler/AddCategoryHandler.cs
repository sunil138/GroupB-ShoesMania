using MediatR;
using Product_PCategory.Commands.CategoryCommands;
using Product_PCategory.DataAccess;

namespace Product_PCategory.Handler.CategoryHandler
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, string>
    {
        private readonly ICategory _category;

        public AddCategoryHandler(ICategory category)
        {
            _category= category;
        }
        public Task<string> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_category.AddNewCategory(request.newCategory));
        }
    }
}

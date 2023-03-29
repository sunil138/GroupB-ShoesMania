using MediatR;
using Product_PCategory.DataAccess;
using Product_PCategory.Models;
using Product_PCategory.Query.ProductCategoryQuerys;

namespace Product_PCategory.Handler.CategoryHandler
{
    public class getCategoryByIdHandler : IRequestHandler<getCategoryByIdQuery, ProductCategory>
    {

        private readonly ICategory _category;

        public getCategoryByIdHandler(ICategory category)
        {
            _category= category;
        }
        public Task<ProductCategory> Handle(getCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_category.GetCategoryById(request.id));
        }
    }
}

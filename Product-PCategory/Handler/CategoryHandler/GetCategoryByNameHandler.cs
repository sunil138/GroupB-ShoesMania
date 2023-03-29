using MediatR;
using Product_PCategory.DataAccess;
using Product_PCategory.Models;
using Product_PCategory.Query.ProductCategoryQuerys;

namespace Product_PCategory.Handler.CategoryHandler
{
    public class GetCategoryByNameHandler : IRequestHandler<getCategoryByName, List<ProductCategory>>
    {
        private readonly ICategory _category;

        public GetCategoryByNameHandler(ICategory category)
        {
            _category= category;
        }
        public Task<List<ProductCategory>> Handle(getCategoryByName request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_category.GetCategoryByName(request.name));
        }
    }
}

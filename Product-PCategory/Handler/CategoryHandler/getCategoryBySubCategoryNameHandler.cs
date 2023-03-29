using MediatR;
using Product_PCategory.DataAccess;
using Product_PCategory.Models;
using Product_PCategory.Query.ProductCategoryQuerys;

namespace Product_PCategory.Handler.CategoryHandler
{
    public class getCategoryBySubCategoryNameHandler : IRequestHandler<getCategoryBySubCategoryNameQuery, List<ProductCategory>>
    {
        private readonly ICategory _category;

        public getCategoryBySubCategoryNameHandler(ICategory category)
        {
            _category= category;
        }
        public Task<List<ProductCategory>> Handle(getCategoryBySubCategoryNameQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_category.GetCategoryBySubCategoryName(request.name));
        }
    }
}

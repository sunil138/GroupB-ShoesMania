using MediatR;
using Product_PCategory.DataAccess;
using Product_PCategory.Models;
using Product_PCategory.Query.ProductCategoryQuerys;

namespace Product_PCategory.Handler.CategoryHandler
{
    public class GetAllCategoryHandler : IRequestHandler<ProductCategoryQuery, List<ProductCategory>>
    {
        private readonly ICategory _category;

        public GetAllCategoryHandler(ICategory category)
        {
            _category= category;
        }
        public Task<List<ProductCategory>> Handle(ProductCategoryQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_category.GetAllCategories());
        }
    }
}

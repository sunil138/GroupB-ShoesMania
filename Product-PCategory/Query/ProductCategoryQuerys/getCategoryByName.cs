using MediatR;
using Product_PCategory.Models;

namespace Product_PCategory.Query.ProductCategoryQuerys
{
    public record getCategoryByName(string name):IRequest<List<ProductCategory>>
    {
    }
}

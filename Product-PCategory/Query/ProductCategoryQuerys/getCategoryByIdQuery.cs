using MediatR;
using Product_PCategory.Models;

namespace Product_PCategory.Query.ProductCategoryQuerys
{
    public record getCategoryByIdQuery(int id):IRequest<ProductCategory>
    {
    }
}

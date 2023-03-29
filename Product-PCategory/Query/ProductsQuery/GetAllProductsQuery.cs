using MediatR;
using Product_PCategory.Models;

namespace Product_PCategory.Query.ProductsQuery
{
    public record GetAllProductsQuery:IRequest<List<Product>>
    {
    }
}

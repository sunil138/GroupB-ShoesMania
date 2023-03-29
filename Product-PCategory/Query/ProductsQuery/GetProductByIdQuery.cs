using MediatR;
using Product_PCategory.Models;

namespace Product_PCategory.Query.ProductsQuery
{
    public record GetProductByIdQuery(int id):IRequest<Product>
    {
    }
}

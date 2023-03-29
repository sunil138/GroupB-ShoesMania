using MediatR;
using Product_PCategory.DataAccess;
using Product_PCategory.Models;
using Product_PCategory.Query.ProductsQuery;

namespace Product_PCategory.Handler.ProductHandler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProduct _product;

        public GetProductByIdHandler(IProduct product)
        {
            _product = product;
        }

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_product.GetProductById(request.id));
        }
    }
}

using MediatR;
using Product_PCategory.DataAccess;
using Product_PCategory.Models;
using Product_PCategory.Query.ProductsQuery;

namespace Product_PCategory.Handler.ProductHandler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProduct _product;

        public GetAllProductsHandler(IProduct product)
        {
            _product = product;
        }
    
        public Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.getAllProducts());
        }
    }
}

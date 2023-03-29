using MediatR;
using Product_PCategory.Commands.ProductCommands;
using Product_PCategory.DataAccess;

namespace Product_PCategory.Handler.ProductHandler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IProduct _product;

        public UpdateProductHandler(IProduct product)
        {
            _product = product;
        }

        public Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.UpdateProduct(request.updateProduct));
        }
    }
}

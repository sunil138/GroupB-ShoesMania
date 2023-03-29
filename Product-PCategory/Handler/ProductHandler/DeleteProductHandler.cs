using MediatR;
using Product_PCategory.Commands.ProductCommands;
using Product_PCategory.DataAccess;

namespace Product_PCategory.Handler.ProductHandler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProduct _product;

        public DeleteProductHandler(IProduct product)
        {
            _product = product;
        }

        public Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.DeleteProduct(request.id));
        }
    }
}

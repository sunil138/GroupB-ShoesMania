using MediatR;
using Product_PCategory.Commands.ProductCommands;
using Product_PCategory.DataAccess;

namespace Product_PCategory.Handler.ProductHandler
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, string>
    {
        private readonly IProduct _product;

        public AddProductHandler(IProduct product)
        {
            _product = product;
        }

        public Task<string> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.AddNewProduct(request.newProduct));
        }
    }
}

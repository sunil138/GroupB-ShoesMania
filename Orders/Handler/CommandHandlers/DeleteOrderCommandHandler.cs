using MediatR;
using Orders.Commands;
using Orders.DataAccess;

namespace Orders.Handler.CommandHandlers
{
    public class DeleteOrderCommandHandler:IRequestHandler<DeleteOrderCommand,string>
    {
        private readonly IOrders _orders;
        public DeleteOrderCommandHandler(IOrders orders)
        {
            _orders = orders;
        }

        public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_orders.delete(request.orderId));  
        }
    }
}

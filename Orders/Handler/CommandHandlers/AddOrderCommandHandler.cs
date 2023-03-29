using MediatR;
using Orders.Commands;
using Orders.DataAccess;
using Orders.Models.DTOs;

namespace Orders.Handler.CommandHandlers
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderPlacedResponseDto>
    {
        private readonly IOrders _orders;

        public AddOrderCommandHandler(IOrders orders)
        {
            _orders = orders;
        }

        public Task<OrderPlacedResponseDto> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            return _orders.PlaceOrder(request.placeOrder);
        }
    }
}

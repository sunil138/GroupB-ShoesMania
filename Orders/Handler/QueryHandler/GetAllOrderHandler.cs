using MediatR;
using Orders.DataAccess;
using Orders.Models;
using Orders.Query;

namespace Orders.Handler.QueryHandler
{
    public class GetAllOrderHandler:IRequestHandler<GetAllOrderQuery,List<Order>>
    {
        private readonly IOrders _orders;
        public GetAllOrderHandler(IOrders orders)
        {
            _orders = orders;
        }

        public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_orders.GetAllOrders()); 
        }
    }
}

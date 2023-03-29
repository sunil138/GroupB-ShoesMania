using MediatR;
using Orders.Models;

namespace Orders.Query
{
    public record GetAllOrderQuery:IRequest<List<Order>>; 
   
}

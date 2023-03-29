using Orders.Models;
using Orders.Models.DTOs;

namespace Orders.DataAccess
{
    public interface IOrders
    {
        Task<OrderPlacedResponseDto> PlaceOrder(OrderRequestDto placeOrder);

        public List<Order> GetAllOrders();
        public string delete(int orderId); 
    }
}

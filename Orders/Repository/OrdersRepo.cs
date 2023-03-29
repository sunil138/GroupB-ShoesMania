using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Orders.DataAccess;
using Orders.Models;
using Orders.Models.DTOs;
using System.Net.Http;

namespace Orders.Repository
{
    public class OrdersRepo : IOrders
    {
        private readonly OrdersDbContext _context;
        private readonly HttpClient _HttpClient;
        public OrdersRepo(OrdersDbContext context, HttpClient httpClient)
        {
            _context = context;
            _HttpClient = httpClient;
        }

        public string delete(int orderId) 
        {
            var orderIdone = _context.Orders.Find(orderId);
            if (orderId != null)
            {
                _context.Orders.Remove(orderIdone);
                _context.SaveChanges();
                return "Deleted Successfully";
            }
            else
            {
                return "Id not Found";
            }
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList(); 
        }

        public async Task<OrderPlacedResponseDto> PlaceOrder(OrderRequestDto placeOrder)
        {
            //get user info
            var response = await _HttpClient.GetAsync($"https://localhost:7196/api/User/getUserById/{placeOrder.UserId}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDetailsDto>(content);

            //get cart info
            var cartResponse = await _HttpClient.GetAsync($"https://localhost:7045/api/Cart/getCartByUserId/{placeOrder.UserId}");

            cartResponse.EnsureSuccessStatusCode();

            var cartContent = await cartResponse.Content.ReadAsStringAsync();

            var cart = JsonConvert.DeserializeObject<CartDetailsDto>(cartContent);


            // Create order items from cart items
            var orderItems = cart.CartItems.Select(cartItem => new OrderItems

            {

                ProductId = cartItem.ProductId,

                ProductName = cartItem.ProductName,

                Quantity = cartItem.ProductQuantity,

                Price = cartItem.ProductPrice

            }).ToList();

            // Calculate total amount

            var totalAmount = orderItems.Sum(item => item.Quantity * item.Price);

            // Create order

            var order = new Order
            {

                UserId = placeOrder.UserId,

                UserName = user.userName,

                UserEmail = user.email,

                OrderedOn = DateTime.Now,

               

                TotalAmount = totalAmount,

                OrderStatus = "Pending",

                orderItems = orderItems,

            };
            // Save order to database

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();


            cart.CartItems.Clear();

            await UpdateCart(cart);

            // Retrieve the newly created order from the database

            var newOrder = await _context.Orders.Include(o => o.orderItems).FirstOrDefaultAsync(o => o.OrderId == order.OrderId);




            // Return success response

            var returnResponse = new OrderPlacedResponseDto

            {

                OrderId = order.OrderId,

                UserId = order.UserId,

                OrderDate = order.OrderedOn,

                TotalAmount = order.TotalAmount,

                OrderStatus = order.OrderStatus,

                OrderItems = newOrder.orderItems.Select(item => new OrderItems
                {
                    ProductId = item.ProductId,

                    Quantity = item.Quantity,

                    Price = item.Price,

                    ProductName = item.ProductName
                }).ToList()


            };

            return returnResponse;



        }

        private async Task UpdateCart(CartDetailsDto cart)
        {


            
            

            var responseCart = await _HttpClient.PutAsJsonAsync(
                $"https://localhost:7045/api/Cart/updateCart/{cart.UserId}", cart);
            responseCart.EnsureSuccessStatusCode();
                

        }
    }
}

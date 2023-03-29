using Cart_CartItems.DataAccess;
using Cart_CartItems.Models;
using Cart_CartItems.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;


namespace Cart_CartItems.Repository
{
    public class CartRepo:ICart
    {
        private readonly CartDbContext _context;
       private readonly HttpClient _HttpClient;

        public CartRepo(CartDbContext context, HttpClient HttpClient)
        {
            _context = context;
            _HttpClient= HttpClient;

        }

        public async Task<Cart> AddToCart(int userId, GetProductIdDto productRequest)
        {
            //should get userId and productId
            //then with this ID fetch all details using api's
            //then add them to cart 
            //var user = await GetUserByIdAsync(userId);
            var response = await _HttpClient.GetAsync($"https://localhost:7196/api/User/getUserById/{userId}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDetailsDto>(content);

            var responseProduct = await _HttpClient.GetAsync($"https://localhost:7202/api/Product/getProductById/{productRequest.ProductId}");

            responseProduct.EnsureSuccessStatusCode();

            var contentProduct = await responseProduct.Content.ReadAsStringAsync();

            var product = JsonConvert.DeserializeObject<ProductDetailsDto>(contentProduct);

            //var product = await GetProductByIdAsync(productRequest.ProductId);

            var cart = await _context.Carts.Include(x => x.CartItems).FirstOrDefaultAsync(x=>x.UserId==userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItems>() };
                _context.Carts.Add(cart);
            }
          

               


                var cartItem = cart.CartItems.FirstOrDefault(i => i.ProductId == productRequest.ProductId);



                if (cartItem == null)

                {

                    cartItem = new CartItems

                    {

                        ProductId = productRequest.ProductId,

                        ProductName = product.Name,

                        ProductQuantity = productRequest.Qunatity,

                        ProductPrice = product.Price

                    };

                    cart.CartItems.Add(cartItem);

                }

                else

                {

                    cartItem.ProductQuantity += productRequest.Qunatity;

                }



                await _context.SaveChangesAsync(); 

                return cart;

            }

            public async Task<UserDetailsDto> GetUserByIdAsync(int userId)

            {

                try
                {

                    var response = await _HttpClient.GetAsync($"https://localhost:7196/api/User/getUserById/{userId}");

                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();

                    var user = JsonConvert.DeserializeObject<UserDetailsDto>(content);



                    return user;

                }

                catch (HttpRequestException ex)

                {

                    throw new ApplicationException($"An error occurred while retrieving user with ID '{userId}': {ex.Message}", ex);

                }

            }



            public async Task<ProductDetailsDto> GetProductByIdAsync(int productId)

            {

                try
                {

                    var response = await _HttpClient.GetAsync($"https://localhost:7202/api/Product/getProductById/{productId}");

                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();

                    var product = JsonConvert.DeserializeObject<ProductDetailsDto>(content);



                    return product;

                }

                catch (HttpRequestException ex)

                {

                    throw new ApplicationException($"An error occurred while retrieving product with ID '{productId}': {ex.Message}", ex);

                }

            }

        public Task<List<Cart>> GetAllCart()
        {
            return Task.FromResult(_context.Carts.Include(x=> x.CartItems).ToList());
        }

        public string RemoveCartItems(int CartItemsId)
        {
            var getCartItemId = _context.CartItems.Find(CartItemsId);
            if (getCartItemId != null)
            {
               _context.CartItems.Remove(getCartItemId);

                _context.SaveChanges();
                return "delted successfully";

            }
            else
            {
                return "Not Found.";
            }
        }

        public Task<Cart> GetCartByUserId(int userId)
        {
            return Task.FromResult(_context.Carts.Include(x=>x.CartItems).Where(x=>x.UserId==userId).FirstOrDefault());
        }

        public async Task<bool> updateCart(int userId,Cart cart)
        {
            //_context.Carts.Update(cart);
            //_context.SaveChanges();
            //return "updated successfully";

            //var getCartId = _context.Carts.Find(cart.Id);
            //if (getCartId != null)
            //{
            //    getCartId.CartItems = cart.CartItems;

            //    _context.SaveChanges();
            //    return "update successfully";

            //}
            //else
            //{
            //    return "cannot update the details.";
            //}

            var existingCart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
            if (existingCart == null)
            {
                return false;
            }



            existingCart.CartItems.Clear();
            existingCart.CartItems = existingCart.CartItems.Concat(cart.CartItems).ToList();



            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                // handle exception
                return false;
            }
        }
    }

       
    }


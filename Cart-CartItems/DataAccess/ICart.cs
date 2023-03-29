using Cart_CartItems.Models;
using Cart_CartItems.Models.DTO;

namespace Cart_CartItems.DataAccess
{
    public interface ICart
    {
        Task<Cart> AddToCart(int userId, GetProductIdDto productDetails);

        Task<UserDetailsDto> GetUserByIdAsync(int userId);

        Task<ProductDetailsDto> GetProductByIdAsync(int productId);

        Task<List<Cart>> GetAllCart();

        string RemoveCartItems(int CartItemsId);

        Task<Cart> GetCartByUserId(int userId);

        Task<bool> updateCart(int userId, Cart cart);

        

    }
}

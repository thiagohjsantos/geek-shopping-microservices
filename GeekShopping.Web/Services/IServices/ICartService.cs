using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(string userId, string token);
        Task<CartViewModel> AddItemToCart(CartViewModel cartModel, string token);
        Task<CartViewModel> UpdateCart(CartViewModel cartModel, string token);
        Task<bool> RemoveFromCart(long cartId, string token);
        Task<bool> ApplyCoupon(CartViewModel cartModel, string token);
        Task<bool> RemoveCoupon(string userId, string token);
        Task<bool> ClearCart(string userId, string token);
        Task<CartViewModel> Checkout(CartHeaderViewModel cartHeaderModel, string token);
    }
}

using OnLineShop.Db.Models;

namespace OnLineShop.Db.Interfaces
{
    public interface IFavoritesRepository
    {
        Task<List<Product>> GetAllAsync(string userId);
        Task AddAsync(Product product, string userId);
        Task ClearAsync(string userId);
        Task RemoveAsync(Guid productId, string userId);
    }
}
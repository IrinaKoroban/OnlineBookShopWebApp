using Microsoft.AspNetCore.Http;
using OnLineShop.Db.Models;


namespace OnLineShop.Db.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> TryGetByNameAsync(string productName);
        Task<Product> TryGetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product, IFormFile[] images);
        Task RestoreAsync(Guid Id);
        Task RemoveAsync(Guid Id);
        Task AddAmountAsync(Guid Id);
        Task ReduceAmountAsync(Guid Id);
    }
}
using OnLineShop.Db.Models;

namespace OnLineShop.Db.Interfaces
{
    public interface IUserDeliveryDataRepository
    {
        Task<UserDeliveryData> TryGetByEmailAsync(string userName);
        Task AddAsync(UserDeliveryData userDeliveryData);
        Task UpdateAsync(UserDeliveryData userDeliveryData);
        Task<List<UserDeliveryData>> GetAllAsync();
        Task<UserDeliveryData> CreateNewAsync(string userEmail);
    }
}
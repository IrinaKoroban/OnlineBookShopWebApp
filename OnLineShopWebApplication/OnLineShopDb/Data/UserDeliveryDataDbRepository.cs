using Microsoft.EntityFrameworkCore;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;

namespace OnLineShop.Db.Data
{
    public class UserDeliveryDataDbRepository : IUserDeliveryDataRepository
    {
        private readonly DatabaseContext databaseContext;

        public UserDeliveryDataDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<UserDeliveryData>> GetAllAsync()
        {
            return await databaseContext.UserDeliveryData.ToListAsync();
        }

        public async Task<UserDeliveryData> TryGetByEmailAsync(string userEmail)
        {
            return await databaseContext.UserDeliveryData.FirstOrDefaultAsync(u => u.Email == userEmail);
        }

        public async Task AddAsync(UserDeliveryData userDeliveryData)
        {
            var existingUserDeliveryData = await TryGetByEmailAsync(userDeliveryData.Email);
            if (existingUserDeliveryData == null)
            {
                databaseContext.UserDeliveryData.Add(userDeliveryData);
                await databaseContext.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(UserDeliveryData userDeliveryData)
        {
            var existingUserDeliveryData = await TryGetByEmailAsync(userDeliveryData.Email);
            if (existingUserDeliveryData != null)
            {
                existingUserDeliveryData.Address = userDeliveryData.Address;
                existingUserDeliveryData.Name = userDeliveryData.Name;
                existingUserDeliveryData.Phone = userDeliveryData.Phone;

                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task<UserDeliveryData> CreateNewAsync(string userEmail)
        {
            var userDeliveryData = new UserDeliveryData { Email = userEmail };
            await databaseContext.AddAsync(userDeliveryData);
            await databaseContext.SaveChangesAsync();
            return userDeliveryData;
        }
    }
}


using Microsoft.EntityFrameworkCore;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;

namespace OnLineShop.Db.Data
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Order> TryGetByIdAsync(Guid orderId)
        {
            return await databaseContext.Orders.Include(x => x.UserDeliveryData).Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == orderId);
        }
        public async Task AddAsync(Order newOrder)
        {
            await databaseContext.Orders.AddAsync(newOrder);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await databaseContext.Orders.Include(x => x.UserDeliveryData).Include(x => x.Items).ThenInclude(x => x.Product).ToListAsync();
        }

        public async Task UpdateStatusAsync(Guid orderId, OrderStatus Status)
        {
            var existingOrder = await TryGetByIdAsync(orderId);
            existingOrder.Status = Status;
            await databaseContext.SaveChangesAsync();
        }
        public async Task<List<Order>> TryGetByUserEmailAsync(string userEmail)
        {
            var orders = databaseContext.Orders.Include(x => x.UserDeliveryData).Include(x => x.Items).ThenInclude(x => x.Product).Where(x => x.UserDeliveryData.Email == userEmail).ToList();
            return orders;
        }
    }
}

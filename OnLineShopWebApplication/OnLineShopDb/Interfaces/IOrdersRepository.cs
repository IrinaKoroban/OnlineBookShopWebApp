using OnLineShop.Db.Models;

namespace OnLineShop.Db.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllAsync();
        Task AddAsync(Order order);
        Task<Order> TryGetByIdAsync(Guid orderId);
        Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus);
        Task<List<Order>> TryGetByUserEmailAsync(string userId);

	}
}
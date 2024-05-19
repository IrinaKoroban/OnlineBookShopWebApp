using Microsoft.EntityFrameworkCore;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;


namespace OnLineShop.Db.Data
{
    public class FavoritesDbRepository : IFavoritesRepository
    {
        private readonly DatabaseContext databaseContext;

        public FavoritesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Product>> GetAllAsync(string userName)
        {
            return await databaseContext.Favorites.Where(u => u.UserEmail == userName).Include(x => x.Product).ThenInclude(x => x.Images).Select(x => x.Product).ToListAsync();
        }
        public async Task AddAsync(Product product, string userId)
        {
            var existingProduct = await databaseContext.Favorites
                .FirstOrDefaultAsync(x => x.UserEmail == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                databaseContext.Favorites.Add(new Favorites { Product = product, UserEmail = userId });
                await databaseContext.SaveChangesAsync();
            }
        }
        public async Task RemoveAsync(Guid productId, string userName)
        {
            var removingFavorites = await databaseContext.Favorites
                .FirstOrDefaultAsync(u => u.UserEmail == userName && u.Product.Id == productId);

            databaseContext.Favorites.Remove(removingFavorites);
            await databaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userId)
        {
            var userFavoritesProducts = await databaseContext.Favorites
                .Where(u => u.UserEmail == userId)
                .ToListAsync();

            databaseContext.Favorites.RemoveRange(userFavoritesProducts);
            await databaseContext.SaveChangesAsync();
        }
    }
}


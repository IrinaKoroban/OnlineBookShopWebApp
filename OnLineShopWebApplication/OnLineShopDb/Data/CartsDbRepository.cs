using Microsoft.EntityFrameworkCore;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;


namespace OnLineShop.Db.Data
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext databaseContext;
        private readonly IdentityContext identityContext;

        public CartsDbRepository(DatabaseContext databaseContext, IdentityContext identityContext)
        {
            this.databaseContext = databaseContext;
            this.identityContext = identityContext;
        }
        public async Task<Cart> TryGetByUserIdAsync(string userName)
        {
            return await databaseContext.Carts.Include(cart => cart.Items).ThenInclude(cartItem => cartItem.Product).FirstOrDefaultAsync(cart => cart.UserId == userName);
        }

        public async Task AddAsync(Product product, string userName)
        {
            var existingCart = await TryGetByUserIdAsync(userName);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userName,
                };

                var Items = new List<CartItem>
                { new CartItem
                        {
                            Product = product,
                            Amount = 1
                        }
                };
                newCart.Items.AddRange(Items);
                await databaseContext.Carts.AddAsync(newCart);
            }

            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount++;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Amount = 1,
                        Product = product,
                    });
                }
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task DecreaseAmountAsync(Guid productId, string userName)
        {
            var existingCart = await TryGetByUserIdAsync(userName);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(item => item.Product.Id == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Amount--;
                if (existingCartItem.Amount == 0)
                    existingCart.Items.Remove(existingCartItem);
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task ClearAsync(string userName)
        {
            var existingCart = await TryGetByUserIdAsync(userName);
            databaseContext.Carts.Remove(existingCart);
            await databaseContext.SaveChangesAsync();
        }
    }
}

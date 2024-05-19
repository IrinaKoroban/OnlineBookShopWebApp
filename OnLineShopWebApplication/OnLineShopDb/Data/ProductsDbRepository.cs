using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;


namespace OnLineShop.Db.Data
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;
        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await databaseContext.Products.Include(x => x.Images).ToListAsync();
        }
        public async Task<List<Product>> TryGetByNameAsync(string productName)
        {
            return await databaseContext.Products.Include(p => p.Images).Where(product => product.Name.ToLower().Contains(productName.ToLower()))?.ToListAsync();
        }
        public async Task<Product> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Products.Include(x => x.Images).FirstOrDefaultAsync(product => product.Id == id);
        }
        public async Task AddAsync(Product newProduct)
        {
            await databaseContext.Products.AddAsync(newProduct);
            await databaseContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product, IFormFile[] uploadedFiles)
        {
            var currentProduct = await TryGetByIdAsync(product.Id);
            currentProduct.Author = product.Author;
            currentProduct.Name = product.Name;
            currentProduct.Cost = product.Cost;
            currentProduct.Description = product.Description;
            currentProduct.ISBN = product.ISBN;
            currentProduct.PublishingHouse = product.PublishingHouse;
            currentProduct.Category = product.Category;
            currentProduct.YearRelease = product.YearRelease;

            if (uploadedFiles != null)
            {
                //foreach (var image in currentProduct.Images)
                //{
                //    databaseContext.Images.Remove(image);
                //}
                foreach (var image in product.Images)
                {
                    image.ProductId = product.Id;
                    databaseContext.Images.Add(image);
                }
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(Guid Id)
        {
            var product = await TryGetByIdAsync(Id);
            product.IsDeleted = true;
            await databaseContext.SaveChangesAsync();
        }
        public async Task RestoreAsync(Guid Id)
        {
            var product = await TryGetByIdAsync(Id);
            product.IsDeleted = false;
            await databaseContext.SaveChangesAsync();
        }

        public async Task AddAmountAsync(Guid Id)
        {
            var product = await TryGetByIdAsync(Id);
            product.Amount++;
            await databaseContext.SaveChangesAsync();
        }
        public async Task ReduceAmountAsync(Guid Id)
        {
            var product = await TryGetByIdAsync(Id);
            if (product.Amount == 0)
                return;
            product.Amount--;
            await databaseContext.SaveChangesAsync();
        }
    }
}

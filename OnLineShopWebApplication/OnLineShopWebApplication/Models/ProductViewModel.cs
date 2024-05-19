using OnLineShop.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public BookCategoryViewModel Category { get; set; }
        public string[] Images { get; set; }
        public string ImagePath => Images.Length == 0 ? "/images/Products/BookCover.jpg" : Images[0];
        public bool IsDeleted { get; set; }
        public int Amount { get; set; }
        public string PublishingHouse { get; set; }
        public string ISBN { get; set; }
        public int YearRelease { get; set; }

    }
}

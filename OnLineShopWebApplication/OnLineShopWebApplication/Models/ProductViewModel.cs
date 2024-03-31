using OnLineShop.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

       // [Required(ErrorMessage = "Автор должен быть заполнен.")]
        public string Author { get; set; }

       // [Required(ErrorMessage = "Имя должно быть заполнено.")]
        public string Name { get; set; }

        // [Required(ErrorMessage = "Цена должна быть указана")]
        // [Range(0, 100000000)]
        public decimal Cost { get; set; }

       // [Required(ErrorMessage = "Описание должно быть заполнено.")]
        public string Description { get; set; }

        public BookCategoryViewModel Category { get; set; }

        public string[] Images { get; set; }

        public string ImagePath => Images.Length == 0 ? "/images/Products/BookCover.jpg" : Images[0];

        public bool IsDeleted { get; set; }

        public string PublishingHouse { get; set; }
        public string ISBN { get; set; }
        public int YearRelease { get; set; }

    }
}

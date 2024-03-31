using OnLineShopWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Areas.Admin.Models
{
    public class AddProductViewModel
    {

        [Required(ErrorMessage = "Автор должен быть заполнен.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Имя должно быть заполнено.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена должна быть указана")]
        [Range(0, 100000000)]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Описание должно быть заполнено.")]
        public string Description { get; set; }

        public IFormFile[] UploadedFiles { get; set; }

        [Required(ErrorMessage = "Издательсвто должно быть заполнено.")]
        public string PublishingHouse { get; set; }
        [Required(ErrorMessage = "Категория должна быть заполнена.")]
        public BookCategoryViewModel Category { get; set; }
        [Required(ErrorMessage = "ISBN должен быть заполнен.")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Год выпуска должен быть заполнен")]
        public int YearRelease { get; set; }
    }
}

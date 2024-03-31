using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
    public class ChangePhoneViewModel
    {
		public string Email { get; set; }

        [Required(ErrorMessage = "Не укзан новый телефон.")]
        [StringLength(25, ErrorMessage = "Телефон должен быть от 5 до 25 символов.", MinimumLength = 5)]
        public string NewPhone { get; set; }
    }
}

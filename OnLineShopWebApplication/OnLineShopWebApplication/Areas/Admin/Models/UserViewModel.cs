

using OnLineShopWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Areas.Admin.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Почта не должна быть пустой.")]
        [EmailAddress(ErrorMessage = "Некорректный адрес.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходмио ввести фамилию и имя")]
        [StringLength(50, ErrorMessage = "ФИО должно быть от 4 до 50 символов. ", MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Телефон не должен быть пустым")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Адрес не должен быть пустым")]
        [Phone]
        public string Address { get; set; }

        [Required(ErrorMessage = "Пароль не должен быть пустым.")]
        [StringLength(25, ErrorMessage = "Пароль должен быть от 5 до 25 символов.", MinimumLength = 5)]
        public string Password { get; set; }

        public UserViewModel() { }
    }
}

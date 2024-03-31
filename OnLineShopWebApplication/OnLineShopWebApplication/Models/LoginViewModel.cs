using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Логин не должен быть пустым")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль не должен быть пустым")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Пароль должен быть от 5 до 25 символов", MinimumLength = 5)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}

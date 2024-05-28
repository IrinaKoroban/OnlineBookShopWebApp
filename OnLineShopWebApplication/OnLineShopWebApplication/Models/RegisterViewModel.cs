using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Логин не должен быть пустым.")]
        [EmailAddress(ErrorMessage = "Некорректный адрес.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль не должен быть пустым.")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Пароль должен быть от 5 до 25 символов.", MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не укзан повторный пароль.")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Пароль должен быть от 5 до 25 символов.", MinimumLength = 5)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}

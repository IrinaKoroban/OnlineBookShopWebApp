using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Areas.Admin.Models
{
    public class ChangePasswordViewModel
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль не должен быть пустым.")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Пароль должен быть от 5 до 25 символов.", MinimumLength = 5)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Не укзан новый пароль.")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Пароль должен быть от 5 до 25 символов.", MinimumLength = 5)]
        public string NewPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
    public class UserDeliveryDataViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Необходмио ввести фамилию и имя")]
        [StringLength(50, ErrorMessage = "ФИО должно быть от 4 до 50 символов. ", MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Почта не должна быть пустой.")]
        [EmailAddress(ErrorMessage = "Некорректный адрес.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон не должен быть пустым")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Адрес должен быть заполнен")]
        public string Address { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
	public class UserDeliveryDataViewModel
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Имя не должно быть пустым")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Телефон не должен быть пустым")]
		[Phone]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Адрес должен быть заполнен")]
		public string Address { get; set; }
	}
}



using OnLineShop.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
    public class UserDetailsViewModel
    {
		[Required(ErrorMessage = "Почта должна быть заполнена.")]
		public string Email { get; set; }

		//[Required(ErrorMessage = "Имя должно быть заполнено.")]
		//public string Name { get; set; }

		[Required(ErrorMessage = "Телефон должен быть заполнен.")]
		public string Phone { get; set; }


		//public UserDetailsViewModel()
  //      {

  //      }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Поле названия роли должно быть заполнено")]
        public string Name { get; set; }

		public override bool Equals(object? obj)
		{
			var role = obj as RoleViewModel;
			return Name == role.Name;
		}
	}
}

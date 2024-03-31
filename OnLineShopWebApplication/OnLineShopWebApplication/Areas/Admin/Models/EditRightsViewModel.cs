namespace OnLineShopWebApplication.Areas.Admin.Models
{
    public class EditRightsViewModel
    {
        public string Email {  get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }
    }
}

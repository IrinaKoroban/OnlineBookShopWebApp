using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;
using OnLineShopWebApplication.Helpers;


namespace OnLineShopWebApplication.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
		private readonly RoleManager<IdentityRole> roleManager;

		public RoleController(RoleManager<IdentityRole> roleManager)
        {
			this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles.Select(role => new RoleViewModel { Name = role.Name}).ToList());
        }


		public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(RoleViewModel role)
        {
            if (await roleManager.FindByNameAsync(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
				await roleManager.CreateAsync(new Role { Name = role.Name});
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

		public async Task<IActionResult> Remove(string roleName)
		{
			var role = await roleManager.FindByNameAsync(roleName);
			if (role != null)
			{
				await roleManager.DeleteAsync(role);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}

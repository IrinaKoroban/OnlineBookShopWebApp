using AutoMapper;
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
    public class UserController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

		public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{
			var users = userManager.Users.ToList();
            var userViewModel = mapper.Map<List<UserViewModel>>(users);
			return View(userViewModel);
		}
		public async Task<IActionResult> DetailAsync(string email)
		{
			var user = await userManager.FindByEmailAsync(email);
			return View(mapper.Map<UserViewModel>(user));
		}
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserViewModel newUser)
        {
            if (await userManager.FindByNameAsync(newUser.Name) != null)
            {
                ModelState.AddModelError("", "Такой пользователь уже есть");
            }
            if (ModelState.IsValid)
            {
                User user = new User { Email = newUser.Email, UserName = newUser.Name, PhoneNumber = newUser.Phone };
                // добавляем пользователя
                var result = await userManager.CreateAsync(user, newUser.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
					return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(newUser);
        }
        public async Task<IActionResult> EditAsync(string email)
        {
			var user = await userManager.FindByEmailAsync(email);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel changePassword)
        {
            if (changePassword.Email == changePassword.NewPassword)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(changePassword.Email);
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.NewPassword);
                user.PasswordHash = newHashPassword;
                await userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }

        public IActionResult ChangePassword(string email)
		{
			var changePassword = new ChangePasswordViewModel()
			{
				Email = email,
			};
			return View(changePassword);
		}

        public async Task<IActionResult> EditRightsAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var userRoles = await userManager.GetRolesAsync(user);
            var roles = roleManager.Roles.ToList();
            var model = new EditRightsViewModel
            {
                Email = user.Email,
                Roles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRightsAsync(string email, Dictionary<string, bool> userRolesViewModel)
        {
            if (ModelState.IsValid)
            {
                var userSelectedRoles = userRolesViewModel.Select(x => x.Key);
                var user = await userManager.FindByEmailAsync(email);
                var userRolesVM = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, userRolesVM);
                await userManager.AddToRolesAsync(user, userSelectedRoles);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(EditRightsAsync));
        }
        public async Task<IActionResult> Remove(string email)
		{
			var user = await userManager.FindByEmailAsync(email);
			await userManager.DeleteAsync(user);
			return RedirectToAction(nameof(Index));
		}
	}
}

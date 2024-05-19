using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;
using OnLineShopWebApplication.Helpers;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;
        private readonly IUserDeliveryDataRepository userDeliveryDataRepository;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUserDeliveryDataRepository userDeliveryDataRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.userDeliveryDataRepository = userDeliveryDataRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userDeliveryData = await userDeliveryDataRepository.GetAllAsync();
            return View(mapper.Map<List<UserDeliveryDataViewModel>>(userDeliveryData));
        }
        public async Task<IActionResult> DetailAsync(string email)
        {
            //var user = await userManager.FindByEmailAsync(email);
            var userDeliveryData = await userDeliveryDataRepository.TryGetByEmailAsync(email);
            var detailsViewModel = mapper.Map<UserDeliveryDataViewModel>(userDeliveryData);

            return View(detailsViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserViewModel newUser)
        {
            if (await userManager.FindByEmailAsync(newUser.Email) != null)
            {
                ModelState.AddModelError("", "Такой пользователь уже есть");
            }
            if (ModelState.IsValid)
            {
                User user = new User { Email = newUser.Email };
                // добавляем пользователя
                var result = await userManager.CreateAsync(user, newUser.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
                    // здесь нужно добавить в userDeliveryDataRepository новую информацию!!!
                    await userDeliveryDataRepository.AddAsync(mapper.Map<UserDeliveryData>(newUser));

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
            var userDeliveryData = await userDeliveryDataRepository.TryGetByEmailAsync(email);

            return View(mapper.Map<UserDeliveryDataViewModel>(userDeliveryData));
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(UserDeliveryDataViewModel userDeliveryDataViewModel)
        {
            var userDeliveryData = mapper.Map<UserDeliveryData>(userDeliveryDataViewModel);

            await userDeliveryDataRepository.UpdateAsync(userDeliveryData);

            return View(nameof(Index));
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

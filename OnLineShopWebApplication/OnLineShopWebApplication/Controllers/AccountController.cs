using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using OnLineShop.Db;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;
using OnLineShopWebApplication.Helpers;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly ImagesProvider imagesProvider;
		private readonly IOrdersRepository ordersRepository;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, ImagesProvider imagesProvider, IOrdersRepository ordersRepository)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.mapper = mapper;
			this.imagesProvider = imagesProvider;
			this.ordersRepository = ordersRepository;
		}

		public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                }
            }
            return View(login);
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel() { ReturnUrl = returnUrl ?? "/Home" });
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = register.Email, UserName = register.Email, PhoneNumber = register.Phone };
                
                // добавляем пользователя
                var result = await userManager.CreateAsync(user, register.Password);

				if (result.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

		[Authorize]
		public async Task<IActionResult> DetailsAsync(string email)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userDetailsViewModel = mapper.Map<UserDetailsViewModel>(user);
			return View(userDetailsViewModel);
        }

        public async Task<IActionResult> EditAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var userViewModel = mapper.Map<UserViewModel>(user);
            return View(userViewModel);
        }
		[Authorize]
        public async Task<IActionResult> OrdersAsync(string email)
        {
            var orders = await ordersRepository.TryGetByUserEmailAsync(email);
			var ordersViewModel = mapper.Map<List<OrderViewModel>>(orders);
			return View(ordersViewModel);
		}
		[Authorize]
		public async Task<IActionResult> OrderDetailAsync(Guid orderId)
        {
            var order = await ordersRepository.TryGetByIdAsync(orderId);
            var orderViewModel = mapper.Map<OrderViewModel>(order);
            return View(orderViewModel);
        }

		[Authorize]
		public IActionResult ChangePassword(string email)
		{
			var changePassword = new ChangePasswordViewModel()
			{
				Email = email,
			};
			return View(changePassword);
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel changePassword)
		{
			//if (changePassword.Email == changePassword.NewPassword)
			//{
			//	ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
			//}

			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(changePassword.Email);
				var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.NewPassword);
				user.PasswordHash = newHashPassword;
				await userManager.UpdateAsync(user);
				return RedirectToAction(nameof(Details));
			}
			return RedirectToAction(nameof(ChangePassword));
		}



		//[HttpPost]
		//public async Task<IActionResult> EditAsync(EditUserViewModel userViewModel)
		//{
		//    if (userViewModel.UploadedFiles != null && !ModelState.IsValid)
		//    {
		//        return View(userViewModel);
		//    }
		//    if (userViewModel.UploadedFiles != null)
		//    {
		//        var addedImagesPaths = imagesProvider.SafeFiles(userViewModel.UploadedFiles, ImageFolders.Products);
		//        userViewModel.ImagesPaths = addedImagesPaths;
		//    }
		//    var user = mapper.Map<User>(userViewModel);
		//    await userManager.UpdateAsync(user, userViewModel.UploadedFiles);
		//    return RedirectToAction(nameof(Index));
		//}

	}
	}


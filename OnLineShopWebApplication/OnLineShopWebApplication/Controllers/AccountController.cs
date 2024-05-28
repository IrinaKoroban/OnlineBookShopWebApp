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

namespace OnLineShopWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly ImagesProvider imagesProvider;
        private readonly IOrdersRepository ordersRepository;
        private readonly IUserDeliveryDataRepository userDeliveryDataRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, ImagesProvider imagesProvider, IOrdersRepository ordersRepository, IUserDeliveryDataRepository userDeliveryDataRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.imagesProvider = imagesProvider;
            this.ordersRepository = ordersRepository;
            this.userDeliveryDataRepository = userDeliveryDataRepository;
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
                User user = new() { Email = register.Email, UserName = register.Email };

                // добавляем пользователя
                var result = await userManager.CreateAsync(user, register.Password);


                if (result.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
                    var userDelivelyData = new UserDeliveryData { Email = register.Email };
                    await userDeliveryDataRepository.AddAsync(userDelivelyData);
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
            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userDeliveryData = await userDeliveryDataRepository.TryGetByEmailAsync(email);
            if (userDeliveryData == null)
            {
                userDeliveryData = await userDeliveryDataRepository.CreateNewAsync(email);
            }

            return View(mapper.Map<UserDeliveryDataViewModel>(userDeliveryData));
        }

        // проверить!!! UDDVM
        [Authorize]
        public async Task<IActionResult> EditAsync(string userEmail)
        {
            var userDeliveryData = await userDeliveryDataRepository.TryGetByEmailAsync(userEmail);
            if (userDeliveryData == null)
            {
                var user = await userManager.FindByEmailAsync(userEmail);
                return View(new UserDeliveryDataViewModel { Email = user.Email });
            }
            var userDeliveryDataViewModel = mapper.Map<UserDeliveryDataViewModel>(userDeliveryData);
            return View(userDeliveryDataViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditAsync(UserDeliveryDataViewModel userDeliveryDataViewModel)
        {
            var userDeliveryData = mapper.Map<UserDeliveryData>(userDeliveryDataViewModel);
            await userDeliveryDataRepository.UpdateAsync(userDeliveryData);
            return View("Details", mapper.Map<UserDeliveryDataViewModel>(userDeliveryData));
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

                return View("ChangePasswordSuccess");
            }
            return RedirectToAction(nameof(ChangePassword));
        }


        //[HttpPost]
        //public async Task<IActionResult> EditAsync(UserDetailsViewModel userViewModel)
        //{
        //if (userViewModel.UploadedFiles != null && !ModelState.IsValid)
        //{
        //    return View(userViewModel);
        //}
        //if (userViewModel.UploadedFiles != null)
        //{
        //    var addedImagesPaths = imagesProvider.SafeFiles(userViewModel.UploadedFiles, ImageFolders.Products);
        //    userViewModel.ImagesPaths = addedImagesPaths;
        //}

        //    var user = mapper.Map<User>(userViewModel);
        //    var userDeliveryData = mapper.Map<UserDeliveryData>(userViewModel);
        //    await userManager.UpdateAsync(user);
        //    await userDeliveryDataRepository.UpdateAsync(userDeliveryData);
        //    return RedirectToAction(nameof(Details));
        //}
    }
}


using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;
        private readonly IUserDeliveryDataRepository userDeliveryDataRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository, IMapper mapper, IUserDeliveryDataRepository userDeliveryDataRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
            this.userDeliveryDataRepository = userDeliveryDataRepository;
        }
        public async Task<IActionResult> Index(string userEmail)
        {
            var userDeliveryData = await userDeliveryDataRepository.TryGetByEmailAsync(userEmail);

            if (userDeliveryData == null)
            {
                userDeliveryData = await userDeliveryDataRepository.CreateNewAsync(userEmail);

                return View(mapper.Map<UserDetailsViewModel>(userDeliveryData));
            }

            if (userDeliveryData.Name == null)
            {
                RedirectToAction("CreateNewOrderAsync", userDeliveryData);
            }
            return View(mapper.Map<UserDetailsViewModel>(userDeliveryData));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(UserDetailsViewModel userDetailsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", userDetailsViewModel);
            }
            await userDeliveryDataRepository.UpdateAsync(mapper.Map<UserDeliveryData>(userDetailsViewModel));
            var userDeliveryData = await userDeliveryDataRepository.TryGetByEmailAsync(userDetailsViewModel.Email);
            await AddNewOrder(userDeliveryData);

            return View();
        }

        private async Task AddNewOrder(UserDeliveryData userDeliveryData)
        {
            var existingCart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);
            var newOrder = new Order
            {
                UserDeliveryData = userDeliveryData,
                Items = existingCart.Items,
            };
            await ordersRepository.AddAsync(newOrder);
            await cartsRepository.ClearAsync(User.Identity.Name);
        }

        public async Task<IActionResult> CreateNewOrderAsync(UserDeliveryData userDeliveryData)
        {
            await userDeliveryDataRepository.UpdateAsync(userDeliveryData);

            var existingCart = await cartsRepository.TryGetByUserIdAsync(userDeliveryData.Email);
            var newOrder = new Order
            {
                UserDeliveryData = userDeliveryData,
                Items = existingCart.Items,
            };
            await ordersRepository.AddAsync(newOrder);
            await cartsRepository.ClearAsync(User.Identity.Name);

            return View();
        }
    }
}
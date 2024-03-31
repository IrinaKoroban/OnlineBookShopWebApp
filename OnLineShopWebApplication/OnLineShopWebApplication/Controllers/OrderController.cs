using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Helpers;
using OnLineShopWebApplication.Models;
using System.Runtime.ConstrainedExecution;

namespace OnLineShopWebApplication.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
		private readonly ICartsRepository cartsRepository;
		private readonly IOrdersRepository ordersRepository;
		private readonly IMapper mapper;

		public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository, IMapper mapper)
		{
			this.cartsRepository = cartsRepository;
			this.ordersRepository = ordersRepository;
			this.mapper = mapper;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateNewAsync(UserDeliveryDataViewModel user)
		{

			if (!ModelState.IsValid)
			{
				return View("Index", user);
			}
			var existingCart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);

			var newOrder = new Order
			{
				userDeliveryData = mapper.Map<UserDeliveryData>(user),
				Items = existingCart.Items,
				userEmail = User.Identity.Name,
			};
			await ordersRepository.AddAsync(newOrder);

			await cartsRepository.ClearAsync(User.Identity.Name);
			return View();
		}
	}
}
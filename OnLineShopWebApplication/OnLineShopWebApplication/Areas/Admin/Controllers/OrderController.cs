using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db.Interfaces;
using OnLineShopWebApplication.Models;
using OnLineShopWebApplication.Helpers;
using Microsoft.AspNetCore.Authorization;
using OnLineShop.Db;
using AutoMapper;
using OnLineShop.Db.Models;
using static NuGet.Packaging.PackagingConstants;

namespace OnLineShopWebApplication.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

		public OrderController(IOrdersRepository ordersRepository, IMapper mapper)
		{
			this.ordersRepository = ordersRepository;
			this.mapper = mapper;
		}

		public async Task<IActionResult> Index()
        {
            var orders = await ordersRepository.GetAllAsync();
            var ordersViewModel = mapper.Map<List<OrderViewModel>>(orders);
            return View(ordersViewModel);
        }

        public async Task<IActionResult> DetailAsync(Guid orderId)
        {
            var order = await ordersRepository.TryGetByIdAsync(orderId);
			var ordersViewModel = mapper.Map<OrderViewModel>(order);
			return View(ordersViewModel);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateStatusAsync(Guid orderId, OrderStatusViewModel status)
        {
            await ordersRepository.UpdateStatusAsync(orderId, mapper.Map<OrderStatus>(status));
            return RedirectToAction(nameof(Index));
        }
    }
}

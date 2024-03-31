using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualBasic;
using OnLineShop.Db;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Helpers;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IMapper mapper;

		public CartViewComponent(ICartsRepository cartsRepository, IMapper mapper)
		{
			this.cartsRepository = cartsRepository;
			this.mapper = mapper;
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);
            var cartViewModel = mapper.Map<CartViewModel>(cart);
            var productsCount = cartViewModel?.Amount ?? 0;
            return View("Cart", productsCount);
        }
    }
}

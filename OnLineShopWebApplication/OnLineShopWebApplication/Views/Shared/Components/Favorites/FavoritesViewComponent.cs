using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db.Interfaces;
using OnLineShopWebApplication.Helpers;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Views.Shared.ViewComponents.CartViewComponents
{
    public class FavoritesViewComponent : ViewComponent
    {
        private readonly IFavoritesRepository favoritesRepository;
        private readonly IMapper mapper;

		public FavoritesViewComponent(IFavoritesRepository favoritesRepository, IMapper mapper)
		{
			this.favoritesRepository = favoritesRepository;
			this.mapper = mapper;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var favorites = await favoritesRepository.GetAllAsync(User.Identity.Name);
            var favoritesViewModel = mapper.Map<List<ProductViewModel>>(favorites);
            return View("Favorites", favoritesViewModel.Count());
        }
    }
}

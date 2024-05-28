using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db.Interfaces;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IFavoritesRepository favoritesRepository;
        private readonly IMapper mapper;

        public FavoritesController(IProductsRepository productRepository, IFavoritesRepository favoritesRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.favoritesRepository = favoritesRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var favorites = await favoritesRepository.GetAllAsync(User.Identity.Name);
            var favoriresViewModel = mapper.Map<List<ProductViewModel>>(favorites);
            return View(favoriresViewModel);
        }
        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var product = await productRepository.TryGetByIdAsync(productId);
            await favoritesRepository.AddAsync(product, User.Identity.Name);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> RemoveAsync(Guid productId)
        {
            await favoritesRepository.RemoveAsync(productId, User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ClearAsync()
        {
            await favoritesRepository.ClearAsync(User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
    }
}

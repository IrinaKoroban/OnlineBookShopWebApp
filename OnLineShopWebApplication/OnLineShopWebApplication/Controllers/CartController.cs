using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db.Interfaces;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly IMapper mapper;

        public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);
            var cartViewModel = mapper.Map<CartViewModel>(cart);
            return View(cartViewModel);
        }
        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var product = await productRepository.TryGetByIdAsync(productId);
            await cartsRepository.AddAsync(product, User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DecreaseAmountAsync(Guid productId)
        {
            await cartsRepository.DecreaseAmountAsync(productId, User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ClearAsync()
        {
            await cartsRepository.ClearAsync(User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
    }
}

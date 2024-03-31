using Microsoft.AspNetCore.Mvc;
using OnLineShopWebApplication.Models;
using System.Diagnostics;
using OnLineShopWebApplication.Helpers;
using OnLineShop.Db.Interfaces;
using AutoMapper;

namespace OnLineShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly IMapper mapper;

        public HomeController(IProductsRepository productRepository, ICartsRepository cartsRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productRepository.GetAllAsync();
            var productsViewModel = mapper.Map<List<ProductViewModel>>(products);
			return View(productsViewModel);
        }
		public async Task<IActionResult> About()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> SearchAsync(string productName)
        {
            if (productName != null)
            {
                var products = await productRepository.TryGetByNameAsync(productName);
				var productsViewModel = mapper.Map<List<ProductViewModel>>(products);
				return View("Index", productsViewModel);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
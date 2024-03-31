using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db.Interfaces;
using OnLineShopWebApplication.Helpers;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;
		private readonly IMapper mapper;
		public ProductController(IProductsRepository bookRepository, IMapper mapper)
		{
			this.productRepository = bookRepository;
			this.mapper = mapper;
		}
		public async Task<IActionResult> Index(Guid productId)
        {
            var product =await productRepository.TryGetByIdAsync(productId);
            var productViewModel = mapper.Map<ProductViewModel>(product);
            return View(productViewModel);
        }
    }
}

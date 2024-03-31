using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLineShop.Db;
using OnLineShop.Db.Interfaces;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;
using OnLineShopWebApplication.Helpers;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ImagesProvider imagesProvider;
        private readonly IMapper mapper;

        public ProductController(IProductsRepository productsRepository, ImagesProvider imagesProvider, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.imagesProvider = imagesProvider;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productsRepository.GetAllAsync();
            var productsViewModel = mapper.Map<List<ProductViewModel>>(products);

            return View(productsViewModel);
        }

        public async Task<IActionResult> DetailAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
            var productsViewModel = mapper.Map<ProductViewModel>(product);

            return View(productsViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(newProduct);
            }

            var imagePath = imagesProvider.SafeFiles(newProduct.UploadedFiles, ImageFolders.Products);

            var productDb = newProduct.ToProductDb(imagePath);

            await productsRepository.AddAsync(productDb);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
            var editProductViewModel = mapper.Map<EditProductViewModel>(product);

            return View(editProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditProductViewModel productViewModel)
        {
            if (productViewModel.UploadedFiles != null && !ModelState.IsValid)
            {
                return View(productViewModel);
            }
            if (productViewModel.UploadedFiles != null)
            {
                var addedImagesPaths = imagesProvider.SafeFiles(productViewModel.UploadedFiles, ImageFolders.Products);
                productViewModel.ImagesPaths = addedImagesPaths;
            }
            var product = mapper.Map<Product>(productViewModel);
            await productsRepository.UpdateAsync(product, productViewModel.UploadedFiles);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveAsync(Guid productId)
        {
            await productsRepository.RemoveAsync(productId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RestoreAsync(Guid productId)
        {
            await productsRepository.RestoreAsync(productId);
            return RedirectToAction(nameof(Index));
        }

        // доделать удаление фото товара
        //public async Task<IActionResult> RemoveImage(Guid productId)
        //{
        //    var product = await productsRepository.TryGetByIdAsync(productId);
        //    var productViewModel = mapper.Map<RemoveImageViewModel>(product);
        //    return View(productViewModel);
        //}


	}
}

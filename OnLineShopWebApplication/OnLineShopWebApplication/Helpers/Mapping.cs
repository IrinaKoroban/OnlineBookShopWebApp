using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;
using OnLineShopWebApplication.Models;

namespace OnLineShopWebApplication.Helpers
{
    public static class Mapping
    {
        public static Product ToProductDb(this AddProductViewModel productViewModel, string[] imagesPaths)
        {
            return new Product
            {
                Name = productViewModel.Name,
                Author = productViewModel.Author,
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                IsDeleted = false,
                Images = imagesPaths.Select(x => new Image { Url = x }).ToList(),
                YearRelease = productViewModel.YearRelease,
                PublishingHouse = productViewModel.PublishingHouse,
                Category = productViewModel.Category.ToBookCategory(),
                ISBN = productViewModel.ISBN
            };
        }


        public static BookCategory ToBookCategory(this BookCategoryViewModel category)
        {
            switch (category.ToString())
            {
                case "ArtisticLiterature":
                    return BookCategory.ArtisticLiterature;
                case "ScientificLiterature":
                    return BookCategory.ScientificLiterature;
                case "ChildrenAndParents":
                    return BookCategory.ChildrenAndParents;
                case "ForeignLanguages":
                    return BookCategory.ForeignLanguages;
                case "Training":
                    return BookCategory.Training;
                case "Programming":
                    return BookCategory.Programming;
                default:
                    return BookCategory.Unknown;
            }
        }
    }
}

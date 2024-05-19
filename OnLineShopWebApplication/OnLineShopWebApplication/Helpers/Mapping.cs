using AutoMapper;
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

        // Только для ToProductDb
        public static BookCategory ToBookCategory(this BookCategoryViewModel category)
        {
            return category.ToString() switch
            {
                "ArtisticLiterature" => BookCategory.ArtisticLiterature,
                "ScientificLiterature" => BookCategory.ScientificLiterature,
                "ChildrenAndParents" => BookCategory.ChildrenAndParents,
                "ForeignLanguages" => BookCategory.ForeignLanguages,
                "Training" => BookCategory.Training,
                "Programming" => BookCategory.Programming,
                _ => BookCategory.Unknown,
            };
        }
    }
}

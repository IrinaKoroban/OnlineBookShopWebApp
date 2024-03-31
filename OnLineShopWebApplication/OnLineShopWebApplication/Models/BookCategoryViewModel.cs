using System.ComponentModel.DataAnnotations;


namespace OnLineShopWebApplication.Models
{
    public enum BookCategoryViewModel
    {
        [Display(Name = "Обучение")]
        Training,
        [Display(Name = "Художественная литература")]
        ArtisticLiterature,
        [Display(Name = "Научная литература")]
        ScientificLiterature,
        [Display(Name = "Иностранные языки")]
        ForeignLanguages,
        [Display(Name = "Программирование")]
        Programming,
        [Display(Name = "Дети и родители")]
        ChildrenAndParents,
        [Display(Name = "Неизвестно")]
        Unknown
    }
}

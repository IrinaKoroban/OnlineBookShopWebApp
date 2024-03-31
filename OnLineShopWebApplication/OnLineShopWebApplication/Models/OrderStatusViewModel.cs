using System.ComponentModel.DataAnnotations;


namespace OnLineShopWebApplication.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Создан")]
        Created,
        [Display(Name = "Собран")]
        Processed,
        [Display(Name = "В пути")]
        InTransit,
        [Display(Name = "Отменён")]
        Сancelled,
        [Display(Name = "Доставлен")]
        Delivered
    }
}

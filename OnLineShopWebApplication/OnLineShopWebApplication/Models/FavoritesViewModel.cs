using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;

namespace OnLineShopWebApplication.Models
{
    public class FavoritesViewModel
    {
        public Guid Id { get; set; }
        //public string UserId { get; set; }
        public string UserEmail { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
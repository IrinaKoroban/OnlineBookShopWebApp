using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;

namespace OnLineShopWebApplication.Models
{
    public class FavoritesViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public ProductViewModel Product { get; set;}
    }
}
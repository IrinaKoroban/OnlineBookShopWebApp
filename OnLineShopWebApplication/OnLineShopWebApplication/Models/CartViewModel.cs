using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;

namespace OnLineShopWebApplication.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemViewModel> Items { get; set;}

        public decimal Cost
        {
            get
            {
                return Items?.Sum(item => item.Cost) ?? 0;
            }
        }
        public int Amount
        {
            get
            {
                return Items?.Sum(item => item.Amount) ?? 0;
            }
        }
    }
}
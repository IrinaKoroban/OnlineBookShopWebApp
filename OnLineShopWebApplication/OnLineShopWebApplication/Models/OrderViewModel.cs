using OnLineShop.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string DateTime { get; set; }
        public OrderStatusViewModel Status { get; set; }

        public UserDeliveryDataViewModel UserDeliveryData { get; set; }
        public Decimal Cost { get; set; }
        public List<CartItemViewModel> Items { get; set; }

        public OrderViewModel()
        {
        }
    }
}

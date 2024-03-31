using OnLineShop.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace OnLineShopWebApplication.Models
{
	public class OrderViewModel
	{
		public Guid Id { get; set; }
		public string DateTime { get; set; }
		public string UserEmail { get; set; }
		public OrderStatusViewModel Status { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
        public Decimal Cost { get; set; }
		public List<CartItemViewModel> Items { get; set; }

		public OrderViewModel()
		{
			//Id = Guid.NewGuid();
			//DateTime = DateTime.Now;
			//Status = "Created";
		}
	}
}

using OnLineShopWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace OnLineShopWebApplication.Areas.Admin.Models
{
    public class RemoveImageViewModel
    {
        public Guid ProductId { get; set; } 

        public string ProductName { get; set; }

		public string[] ImagesPaths { get; set; }
    }
}

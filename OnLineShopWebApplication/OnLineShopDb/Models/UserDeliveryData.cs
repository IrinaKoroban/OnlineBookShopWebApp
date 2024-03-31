using System.ComponentModel.DataAnnotations;

namespace OnLineShop.Db.Models
{
    public class UserDeliveryData
    {
        public Guid Id { get; set; }

        // !!!!!!!!!
        //public string UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}

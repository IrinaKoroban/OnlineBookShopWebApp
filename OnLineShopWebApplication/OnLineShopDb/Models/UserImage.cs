using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.Db.Models
{
    public class UserImage
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}

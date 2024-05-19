namespace OnLineShop.Db.Models
{
    public class Favorites
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public Product Product { get; set; }
    }
}


using System.ComponentModel.DataAnnotations.Schema;

namespace OnLineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string PublishingHouse { get; set; }
        public BookCategory Category { get; set; }
        public string ISBN { get; set; }
        public int YearRelease { get; set; }

        public List<Image> Images { get; set; }
        public List<CartItem> CartItems { get; set; }

        public int Amount { get; set; }
        public bool IsDeleted { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
            Images = new List<Image>();
        }

        public Product(Guid id, string name, string author, decimal cost, string description, string publishingHouse, BookCategory category, string isbn, int yearRelease, int amount) : this()
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            Author = author;
            PublishingHouse = publishingHouse;
            Category = category;
            ISBN = isbn;
            YearRelease = yearRelease;
            Amount = amount;
        }
    }
}

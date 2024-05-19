using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnLineShop.Db.Models;
using System.Collections.Generic;

namespace OnLineShop.Db
{
    public class DatabaseContext : DbContext
    {
        // Доступ к таблицам
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<UserDeliveryData> UserDeliveryData { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            var product1Id = Guid.Parse("239fa757-a3cd-475b-b76b-889b78fb0ff3");
            var product2Id = Guid.Parse("86903a15-590b-4b14-bead-3ab140e31fc9");
            var product3Id = Guid.Parse("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7");
            var product4Id = Guid.Parse("23ad0815-e1c3-4822-8e35-7c0678afac48");
            var product5Id = Guid.Parse("62ae7045-bbe3-4da1-9f32-5710c74a8691");
            var product6Id = Guid.Parse("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72");
            var product7Id = Guid.Parse("ffca2c5d-d828-45e8-ad7c-691a54dc140b");
            var product8Id = Guid.Parse("854ea48d-28f9-44b6-a4be-fd3afc36cb3b");
            var product9Id = Guid.Parse("46f56303-c86e-4302-ae88-9210f2b9d383");
            var product10Id = Guid.Parse("810039c6-3bfc-48a1-b2ec-3463c0acdd78");
            var product11Id = Guid.Parse("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb");

            modelBuilder.Entity<Image>().HasData(new List<Image>()
            {
                new Image{Id = Guid.Parse("fab1c1e5-75d2-4472-81c9-104c2c6f489c"), Url = "/images/Products/корабли.jpg", ProductId = product1Id},
                new Image{Id = Guid.Parse("1fc285b9-7fcb-4f48-b7de-5c2cbced9573"), Url = "/images/Products/Concrete.jpg", ProductId = product2Id},
                new Image{Id = Guid.Parse("399f589a-cce2-432a-bf8c-622a4e4eacba"), Url = "/images/Products/Relationship.jpg", ProductId = product3Id},
                new Image{Id = Guid.Parse("2f1cc667-cea5-41fc-b7e9-4e141fd877b9"), Url = "/images/Products/img5.jpg", ProductId = product4Id},
                new Image{Id = Guid.Parse("9dfbc818-070e-487b-a2da-b73f65c4be1b"), Url = "/images/Products/img6.jpg", ProductId = product5Id},
                new Image{Id = Guid.Parse("fd5fb283-0a6c-4682-9a9b-4c68fe1ce188"), Url = "/images/Products/skvoznyak.jpg", ProductId = product6Id},
                new Image{Id = Guid.Parse("7e26ac59-240a-48e3-a0d9-30a393946d37"), Url = "/images/Products/img3.jpg", ProductId = product7Id},
                new Image{Id = Guid.Parse("07b46f56-2ef8-4e8c-9242-742f043da0c1"), Url = "/images/Products/img4.jpg", ProductId = product8Id},
                new Image{Id = Guid.Parse("e170bf17-7e6b-434a-8ca5-ed4942857596"), Url = "/images/Products/planetarium.webp", ProductId = product9Id},
                new Image{Id = Guid.Parse("7e29edb4-22fb-4884-a42e-efaf40ace7e3"), Url = "/images/Products/anatomikum.jpg", ProductId = product10Id},
                new Image{Id = Guid.Parse("d65b5d85-4807-4e25-9fa4-771f0616358e"), Url = "/images/Products/okeanarium.webp", ProductId = product11Id},

            });

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id,"Как избежать огромных кораблей", "Джон Триммер", 1_000, "Книга капитана Джона У. Триммера, капитана морского флота. Советы морякам прогулочных катеров об опасности морских путей.", "Cornwell Maritime Press", BookCategory.Training, "123456789", 1982, 2),
                new Product(product2Id,"Знаменательные моменты из истории бетона", "С. С. Стэнли", 1_000, "Самые важные события, связянные с историей бетона.", "British Cement Association", BookCategory.Training, "23456789", 1980, 200),
                new Product(product3Id,"Начните с собственных ног, если хотите ясности в отношениях", "Биг Бум", 10_000, "Рекомендации об отношениях между людьми.", "Simon&Schuster US", BookCategory.Training, "123456789", 2007, 10),
                new Product(product4Id,"Вязальные приключения с гиперболическими плоскостями", "Дайна Тайминя", 2_000, "Является примером работы по визуализации математических объектов - моделей геометрии Лобачевского с помощью вязания крючком.","A K Peters Ltd.", BookCategory.Training ,"123456789",  2009, 50),

                new Product(product5Id,"Управляем стоматологической клиникой по-чингисхановски", "Майкл Янг", 3_000, "Справочник для управляющего стоматологической клиникой с опорой на великого завоевателя.", "Radclife", BookCategory.Training, "123456789", 2010, 20),
                new Product(product6Id,"Сквозняк из прошлого", "Набоков Владимир Владимирович", 586, "Трагическая любовная история героя книги Хью Тёрсона, помощника главного редактора в крупном американском издательстве.", "неизвестно", BookCategory.ArtisticLiterature, "123456", 1972, 15),
                new Product(product7Id,"Двое из чайника", "Рейси Хелпс", 543, "Невероятно добрая книжка, познакомит юного читателя с путешествиями Кошки Мисс Табиты Пушистый хвост, к которой нагрянули незваные гости - мышки Шустри и Шурши.", "Издательство Гудвин", BookCategory.ArtisticLiterature, "978-5-6043287-3-6", 2020, 30),
                new Product(product8Id,"Перспективы 60-миллиграммовых упаковок для творога на 2009—2014 годы", "Филипп Паркерс", 3_000, "Книга сгенерирована аналитической программой, позволяющей создавать огромное количество узкоспециальных текстов.", "Icon Group International", BookCategory.Training ,"123456789", 2008, 1),

                new Product(product9Id,"Планетариум", "Принджа Раман", 999, "Добро пожаловать в Планетариум. Это постоянно открытый музей готов познакомить посетителей с коллекцией астрономических объектов.", "Махаон", BookCategory.ScientificLiterature, "978-5-389-15275-5", 2020, 10),
                new Product(product10Id,"Анатомикум", "Пакстон Дженнифер", 900, "Добро пожаловать в Анатомикум. Это постоянно открытый музей готов познакомить посетителей с анатомией человека.", "Махаон", BookCategory.ScientificLiterature, "978-5-389-161512-0", 2024, 8),
                new Product(product11Id,"Океанариум", "Триник Лавдэй", 900, "Добро пожаловать в Океанариум. Это постоянно открытый музей приглашает посетителей в путешествие по Мировому океану.", "Махаон", BookCategory.ScientificLiterature, "978-5-389-17989-9", 2024, 50)
            });

            modelBuilder.Entity<Product>().Property(e => e.Category).HasConversion(v => v.ToString(), v => (BookCategory)Enum.Parse(typeof(BookCategory), v));

        }
    }
}

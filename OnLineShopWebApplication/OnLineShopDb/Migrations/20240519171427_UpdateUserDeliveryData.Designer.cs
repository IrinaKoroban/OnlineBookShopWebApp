﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnLineShop.Db;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240519171427_UpdateUserDeliveryData")]
    partial class UpdateUserDeliveryData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnLineShop.Db.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Favorites", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fab1c1e5-75d2-4472-81c9-104c2c6f489c"),
                            ProductId = new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                            Url = "/images/Products/корабли.jpg"
                        },
                        new
                        {
                            Id = new Guid("1fc285b9-7fcb-4f48-b7de-5c2cbced9573"),
                            ProductId = new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                            Url = "/images/Products/Concrete.jpg"
                        },
                        new
                        {
                            Id = new Guid("399f589a-cce2-432a-bf8c-622a4e4eacba"),
                            ProductId = new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                            Url = "/images/Products/Relationship.jpg"
                        },
                        new
                        {
                            Id = new Guid("2f1cc667-cea5-41fc-b7e9-4e141fd877b9"),
                            ProductId = new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                            Url = "/images/Products/img5.jpg"
                        },
                        new
                        {
                            Id = new Guid("9dfbc818-070e-487b-a2da-b73f65c4be1b"),
                            ProductId = new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                            Url = "/images/Products/img6.jpg"
                        },
                        new
                        {
                            Id = new Guid("fd5fb283-0a6c-4682-9a9b-4c68fe1ce188"),
                            ProductId = new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                            Url = "/images/Products/skvoznyak.jpg"
                        },
                        new
                        {
                            Id = new Guid("7e26ac59-240a-48e3-a0d9-30a393946d37"),
                            ProductId = new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                            Url = "/images/Products/img3.jpg"
                        },
                        new
                        {
                            Id = new Guid("07b46f56-2ef8-4e8c-9242-742f043da0c1"),
                            ProductId = new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                            Url = "/images/Products/img4.jpg"
                        },
                        new
                        {
                            Id = new Guid("e170bf17-7e6b-434a-8ca5-ed4942857596"),
                            ProductId = new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                            Url = "/images/Products/planetarium.webp"
                        },
                        new
                        {
                            Id = new Guid("7e29edb4-22fb-4884-a42e-efaf40ace7e3"),
                            ProductId = new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                            Url = "/images/Products/anatomikum.jpg"
                        },
                        new
                        {
                            Id = new Guid("d65b5d85-4807-4e25-9fa4-771f0616358e"),
                            ProductId = new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                            Url = "/images/Products/okeanarium.webp"
                        });
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserDeliveryDataId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserDeliveryDataId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishingHouse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearRelease")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                            Amount = 2,
                            Author = "Джон Триммер",
                            Category = "Training",
                            Cost = 1000m,
                            Description = "Книга капитана Джона У. Триммера, капитана морского флота. Советы морякам прогулочных катеров об опасности морских путей.",
                            ISBN = "123456789",
                            IsDeleted = false,
                            Name = "Как избежать огромных кораблей",
                            PublishingHouse = "Cornwell Maritime Press",
                            YearRelease = 1982
                        },
                        new
                        {
                            Id = new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                            Amount = 200,
                            Author = "С. С. Стэнли",
                            Category = "Training",
                            Cost = 1000m,
                            Description = "Самые важные события, связянные с историей бетона.",
                            ISBN = "23456789",
                            IsDeleted = false,
                            Name = "Знаменательные моменты из истории бетона",
                            PublishingHouse = "British Cement Association",
                            YearRelease = 1980
                        },
                        new
                        {
                            Id = new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                            Amount = 10,
                            Author = "Биг Бум",
                            Category = "Training",
                            Cost = 10000m,
                            Description = "Рекомендации об отношениях между людьми.",
                            ISBN = "123456789",
                            IsDeleted = false,
                            Name = "Начните с собственных ног, если хотите ясности в отношениях",
                            PublishingHouse = "Simon&Schuster US",
                            YearRelease = 2007
                        },
                        new
                        {
                            Id = new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                            Amount = 50,
                            Author = "Дайна Тайминя",
                            Category = "Training",
                            Cost = 2000m,
                            Description = "Является примером работы по визуализации математических объектов - моделей геометрии Лобачевского с помощью вязания крючком.",
                            ISBN = "123456789",
                            IsDeleted = false,
                            Name = "Вязальные приключения с гиперболическими плоскостями",
                            PublishingHouse = "A K Peters Ltd.",
                            YearRelease = 2009
                        },
                        new
                        {
                            Id = new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                            Amount = 20,
                            Author = "Майкл Янг",
                            Category = "Training",
                            Cost = 3000m,
                            Description = "Справочник для управляющего стоматологической клиникой с опорой на великого завоевателя.",
                            ISBN = "123456789",
                            IsDeleted = false,
                            Name = "Управляем стоматологической клиникой по-чингисхановски",
                            PublishingHouse = "Radclife",
                            YearRelease = 2010
                        },
                        new
                        {
                            Id = new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                            Amount = 15,
                            Author = "Набоков Владимир Владимирович",
                            Category = "ArtisticLiterature",
                            Cost = 586m,
                            Description = "Трагическая любовная история героя книги Хью Тёрсона, помощника главного редактора в крупном американском издательстве.",
                            ISBN = "123456",
                            IsDeleted = false,
                            Name = "Сквозняк из прошлого",
                            PublishingHouse = "неизвестно",
                            YearRelease = 1972
                        },
                        new
                        {
                            Id = new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                            Amount = 30,
                            Author = "Рейси Хелпс",
                            Category = "ArtisticLiterature",
                            Cost = 543m,
                            Description = "Невероятно добрая книжка, познакомит юного читателя с путешествиями Кошки Мисс Табиты Пушистый хвост, к которой нагрянули незваные гости - мышки Шустри и Шурши.",
                            ISBN = "978-5-6043287-3-6",
                            IsDeleted = false,
                            Name = "Двое из чайника",
                            PublishingHouse = "Издательство Гудвин",
                            YearRelease = 2020
                        },
                        new
                        {
                            Id = new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                            Amount = 1,
                            Author = "Филипп Паркерс",
                            Category = "Training",
                            Cost = 3000m,
                            Description = "Книга сгенерирована аналитической программой, позволяющей создавать огромное количество узкоспециальных текстов.",
                            ISBN = "123456789",
                            IsDeleted = false,
                            Name = "Перспективы 60-миллиграммовых упаковок для творога на 2009—2014 годы",
                            PublishingHouse = "Icon Group International",
                            YearRelease = 2008
                        },
                        new
                        {
                            Id = new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                            Amount = 10,
                            Author = "Принджа Раман",
                            Category = "ScientificLiterature",
                            Cost = 999m,
                            Description = "Добро пожаловать в Планетариум. Это постоянно открытый музей готов познакомить посетителей с коллекцией астрономических объектов.",
                            ISBN = "978-5-389-15275-5",
                            IsDeleted = false,
                            Name = "Планетариум",
                            PublishingHouse = "Махаон",
                            YearRelease = 2020
                        },
                        new
                        {
                            Id = new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                            Amount = 8,
                            Author = "Пакстон Дженнифер",
                            Category = "ScientificLiterature",
                            Cost = 900m,
                            Description = "Добро пожаловать в Анатомикум. Это постоянно открытый музей готов познакомить посетителей с анатомией человека.",
                            ISBN = "978-5-389-161512-0",
                            IsDeleted = false,
                            Name = "Анатомикум",
                            PublishingHouse = "Махаон",
                            YearRelease = 2024
                        },
                        new
                        {
                            Id = new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                            Amount = 50,
                            Author = "Триник Лавдэй",
                            Category = "ScientificLiterature",
                            Cost = 900m,
                            Description = "Добро пожаловать в Океанариум. Это постоянно открытый музей приглашает посетителей в путешествие по Мировому океану.",
                            ISBN = "978-5-389-17989-9",
                            IsDeleted = false,
                            Name = "Океанариум",
                            PublishingHouse = "Махаон",
                            YearRelease = 2024
                        });
                });

            modelBuilder.Entity("OnLineShop.Db.Models.UserDeliveryData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDeliveryData");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.UserImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserImages");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnLineShop.Db.Models.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnLineShop.Db.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnLineShop.Db.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Favorites", b =>
                {
                    b.HasOne("OnLineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Image", b =>
                {
                    b.HasOne("OnLineShop.Db.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Order", b =>
                {
                    b.HasOne("OnLineShop.Db.Models.UserDeliveryData", "UserDeliveryData")
                        .WithMany()
                        .HasForeignKey("UserDeliveryDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDeliveryData");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnLineShop.Db.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}

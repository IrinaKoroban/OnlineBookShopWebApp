using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "ImgPath", "Name" },
                values: new object[,]
                {
                    { new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"), "Джон Триммер", 1000m, "00", "/images/корабли.jpg", "Как избежать огромных кораблей" },
                    { new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"), "Дайна Тайминя", 2000m, "00", "/images/img5.jpg", "Вязальные приключения с гиперболическими плоскостями" },
                    { new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"), "Принджа Раман", 999m, "00", "/images/planetarium.jpg", "Планетариум" },
                    { new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"), "Майкл Янг", 3000m, "00", "/images/img6.jpg", "Управляем стоматологической клиникой по-чингисхановски" },
                    { new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"), "Пакстон Дженнифер", 900m, "00", "/images/anatonikum.jpg", "Анатомикум" },
                    { new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"), "Филипп Паркерс", 3000m, "00", "/images/img4.jpg", "Перспективы 60-миллиграммовых упаковок для творога на 2009—2014 годы" },
                    { new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"), "С. С. Стэнли", 1000m, "00", "/images/Concrete.jpg", "Знаменательные моменты из истории бетона" },
                    { new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"), "Триник Лавдэй", 900m, "00", "/images/okeanarium.jpg", "Океанариум" },
                    { new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"), "Биг Бум", 10000m, "00", "/images/Relationship.jpg", "Начните с собственных ног, если хотите ясности в отношениях" },
                    { new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"), "Набоков Владимир Владимирович", 586m, "00", "/images/skvoznyak.jpg", "Сквозняк из прошлого" },
                    { new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"), "Рейси Хелпс", 543m, "00", "/images/img3.jpg", "Двое из чайника" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserDeliveryData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PublishingHouse",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearRelease",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImages_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 0, "Книга капитана Джона У. Триммера, капитана морского флота. Советы морякам прогулочных катеров от опасности морских путей.", "123456789", "Cornwell Maritime Press", 1982 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 0, "Является примером работы по визуализации математических объектов - моделей геометрии Лобачевского с помощью вязания крючком.", "123456789", "A K Peters Ltd.", 2009 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 2, "Добро пожаловать в Планетариум. Это постоянно открытый музей готов познакомить посетителей с коллекцией астрономических объектов.", "978-5-389-15275-5", "Махаон", 2020 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 0, "Справочкик для управляющего стоматологической клиникой с опорой на великого завоевателя.", "123456789", "Radclife", 2010 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 2, "Добро пожаловать в Анатомикум. Это постоянно открытый музей готов познакомить посетителей с анатомией целовека.", "978-5-389-161512-0", "Махаон", 2024 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 0, "Книга сгенерирована аналитической программой, позволяющей создавать огромное количество узкоспециальных текстов.", "123456789", "Icon Group International", 2008 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 0, "Самые важные события, связянные с историей бетона", "23456789", "British Cement Association", 1980 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 2, "Добро пожаловать в Океанариум. Это постоянно открытый музей приглашает посетителей в путешествие по Мировому океану.", "978-5-389-17989-9", "Махаон", 2024 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                columns: new[] { "Category", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 0, "123456789", "Simon&Schuster US", 2007 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                columns: new[] { "Category", "Description", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 1, "Трагическая любовная история героя книги Хью Тёрсона, помошика главного редактора в крупном американском издательстве", "123456", "неизвестно", 1972 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                columns: new[] { "Category", "ISBN", "PublishingHouse", "YearRelease" },
                values: new object[] { 1, "978-5-6043287-3-6", "Издательство Гудвин", 2020 });

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId1",
                table: "UserImages",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDeliveryData");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PublishingHouse",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "YearRelease",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                column: "Description",
                value: "00");
        }
    }
}

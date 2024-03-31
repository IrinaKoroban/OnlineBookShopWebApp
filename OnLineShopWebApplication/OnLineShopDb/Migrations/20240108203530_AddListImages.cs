using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddListImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("07b46f56-2ef8-4e8c-9242-742f043da0c1"), new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"), "/images/Products/img4.jpg" },
                    { new Guid("1fc285b9-7fcb-4f48-b7de-5c2cbced9573"), new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"), "/images/Products/Concrete.jpg" },
                    { new Guid("2f1cc667-cea5-41fc-b7e9-4e141fd877b9"), new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"), "/images/Products/img5.jpg" },
                    { new Guid("399f589a-cce2-432a-bf8c-622a4e4eacba"), new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"), "/images/Products/Relationship.jpg" },
                    { new Guid("7e26ac59-240a-48e3-a0d9-30a393946d37"), new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"), "/images/Products/img3.jpg" },
                    { new Guid("7e29edb4-22fb-4884-a42e-efaf40ace7e3"), new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"), "/images/Products/anatonikum.jpg" },
                    { new Guid("9dfbc818-070e-487b-a2da-b73f65c4be1b"), new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"), "/images/Products/img6.jpg" },
                    { new Guid("d65b5d85-4807-4e25-9fa4-771f0616358e"), new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"), "/images/Products/okeanarium.jpg" },
                    { new Guid("e170bf17-7e6b-434a-8ca5-ed4942857596"), new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"), "/images/Products/planetarium.jpg" },
                    { new Guid("fab1c1e5-75d2-4472-81c9-104c2c6f489c"), new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"), "/images/Products/корабли.jpg" },
                    { new Guid("fd5fb283-0a6c-4682-9a9b-4c68fe1ce188"), new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"), "/images/Products/skvoznyak.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                column: "ImgPath",
                value: "/images/Products/корабли.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                column: "ImgPath",
                value: "/images/Products/img5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                column: "ImgPath",
                value: "/images/Products/planetarium.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                column: "ImgPath",
                value: "/images/Products/img6.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                column: "ImgPath",
                value: "/images/Products/anatonikum.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                column: "ImgPath",
                value: "/images/Products/img4.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                column: "ImgPath",
                value: "/images/Products/Concrete.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                column: "ImgPath",
                value: "/images/Products/okeanarium.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                column: "ImgPath",
                value: "/images/Products/Relationship.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                column: "ImgPath",
                value: "/images/Products/skvoznyak.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "ImgPath",
                value: "/images/Products/img3.jpg");
        }
    }
}

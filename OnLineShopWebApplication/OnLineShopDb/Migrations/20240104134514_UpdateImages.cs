using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                column: "ImgPath",
                value: "/images/корабли.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                column: "ImgPath",
                value: "/images/img5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                column: "ImgPath",
                value: "/images/planetarium.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                column: "ImgPath",
                value: "/images/img6.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                column: "ImgPath",
                value: "/images/anatonikum.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                column: "ImgPath",
                value: "/images/img4.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                column: "ImgPath",
                value: "/images/Concrete.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                column: "ImgPath",
                value: "/images/okeanarium.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                column: "ImgPath",
                value: "/images/Relationship.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                column: "ImgPath",
                value: "/images/skvoznyak.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "ImgPath",
                value: "/images/img3.jpg");
        }
    }
}

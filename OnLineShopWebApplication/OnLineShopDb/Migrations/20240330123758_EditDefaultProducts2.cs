using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class EditDefaultProducts2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7e29edb4-22fb-4884-a42e-efaf40ace7e3"),
                column: "Url",
                value: "/images/Products/anatomikum.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "Description",
                value: "Невероятно добрая книжка, познакомит юного читателя с путешествиями Кошки Мисс Табиты Пушистый хвост, к которой нагрянули незваные гости - мышки Шустри и Шурши.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7e29edb4-22fb-4884-a42e-efaf40ace7e3"),
                column: "Url",
                value: "/images/Products/anatonikum.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "Description",
                value: "Невероятно добрая книжка, познкомит юного читателя с путешествиями Кошки Мисс Табиты Пушистый хвост, к которой нагрянули незваные гости - мышки Шустри и Шурши.");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class EditImagesDefaultProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d65b5d85-4807-4e25-9fa4-771f0616358e"),
                column: "Url",
                value: "/images/Products/okeanarium.webp");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e170bf17-7e6b-434a-8ca5-ed4942857596"),
                column: "Url",
                value: "/images/Products/planetarium.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d65b5d85-4807-4e25-9fa4-771f0616358e"),
                column: "Url",
                value: "/images/Products/okeanarium.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e170bf17-7e6b-434a-8ca5-ed4942857596"),
                column: "Url",
                value: "/images/Products/planetarium.jpg");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class CategoryConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                column: "Category",
                value: "Training");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                column: "Category",
                value: "Training");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                column: "Category",
                value: "ScientificLiterature");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                column: "Category",
                value: "Training");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                column: "Category",
                value: "ScientificLiterature");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                column: "Category",
                value: "Training");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                column: "Category",
                value: "Training");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                column: "Category",
                value: "ScientificLiterature");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                column: "Category",
                value: "Training");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                column: "Category",
                value: "ArtisticLiterature");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "Category",
                value: "ArtisticLiterature");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                column: "Category",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23ad0815-e1c3-4822-8e35-7c0678afac48"),
                column: "Category",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f56303-c86e-4302-ae88-9210f2b9d383"),
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                column: "Category",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("854ea48d-28f9-44b6-a4be-fd3afc36cb3b"),
                column: "Category",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                column: "Category",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fe6eb6d-446b-4e81-9a38-b23d396a0ddb"),
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                column: "Category",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                column: "Category",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "Category",
                value: 1);
        }
    }
}

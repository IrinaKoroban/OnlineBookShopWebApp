using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class EditDefaultProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryData_userDeliveryDataId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryData",
                table: "DeliveryData");

            migrationBuilder.RenameTable(
                name: "DeliveryData",
                newName: "UserDeliveryData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDeliveryData",
                table: "UserDeliveryData",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                column: "Description",
                value: "Книга капитана Джона У. Триммера, капитана морского флота. Советы морякам прогулочных катеров об опасности морских путей.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                column: "Description",
                value: "Справочник для управляющего стоматологической клиникой с опорой на великого завоевателя.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                column: "Description",
                value: "Добро пожаловать в Анатомикум. Это постоянно открытый музей готов познакомить посетителей с анатомией человека.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                column: "Description",
                value: "Самые важные события, связянные с историей бетона.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                column: "Description",
                value: "Рекомендации об отношениях между людьми.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                column: "Description",
                value: "Трагическая любовная история героя книги Хью Тёрсона, помощника главного редактора в крупном американском издательстве.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "Description",
                value: "Невероятно добрая книжка, познкомит юного читателя с путешествиями Кошки Мисс Табиты Пушистый хвост, к которой нагрянули незваные гости - мышки Шустри и Шурши.");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserDeliveryData_userDeliveryDataId",
                table: "Orders",
                column: "userDeliveryDataId",
                principalTable: "UserDeliveryData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserDeliveryData_userDeliveryDataId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDeliveryData",
                table: "UserDeliveryData");

            migrationBuilder.RenameTable(
                name: "UserDeliveryData",
                newName: "DeliveryData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryData",
                table: "DeliveryData",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("239fa757-a3cd-475b-b76b-889b78fb0ff3"),
                column: "Description",
                value: "Книга капитана Джона У. Триммера, капитана морского флота. Советы морякам прогулочных катеров от опасности морских путей.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62ae7045-bbe3-4da1-9f32-5710c74a8691"),
                column: "Description",
                value: "Справочкик для управляющего стоматологической клиникой с опорой на великого завоевателя.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("810039c6-3bfc-48a1-b2ec-3463c0acdd78"),
                column: "Description",
                value: "Добро пожаловать в Анатомикум. Это постоянно открытый музей готов познакомить посетителей с анатомией целовека.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86903a15-590b-4b14-bead-3ab140e31fc9"),
                column: "Description",
                value: "Самые важные события, связянные с историей бетона");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c75d304a-8400-46fd-ba7e-f2ad9e02b4c7"),
                column: "Description",
                value: "00");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3e9e6cc-4ed4-4569-8aa9-96fdc51b0c72"),
                column: "Description",
                value: "Трагическая любовная история героя книги Хью Тёрсона, помошика главного редактора в крупном американском издательстве");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffca2c5d-d828-45e8-ad7c-691a54dc140b"),
                column: "Description",
                value: "00");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryData_userDeliveryDataId",
                table: "Orders",
                column: "userDeliveryDataId",
                principalTable: "DeliveryData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

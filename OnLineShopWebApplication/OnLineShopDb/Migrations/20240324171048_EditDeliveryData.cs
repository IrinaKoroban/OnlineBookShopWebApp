using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class EditDeliveryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DeliveryData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryData",
                table: "DeliveryData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryData_userDeliveryDataId",
                table: "Orders",
                column: "userDeliveryDataId",
                principalTable: "DeliveryData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserDeliveryData",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDeliveryData",
                table: "UserDeliveryData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserDeliveryData_userDeliveryDataId",
                table: "Orders",
                column: "userDeliveryDataId",
                principalTable: "UserDeliveryData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

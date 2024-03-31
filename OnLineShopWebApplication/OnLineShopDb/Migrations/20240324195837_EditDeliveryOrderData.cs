using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnLineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class EditDeliveryOrderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DeliveryData");

            migrationBuilder.AddColumn<string>(
                name: "userEmail",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userEmail",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DeliveryData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

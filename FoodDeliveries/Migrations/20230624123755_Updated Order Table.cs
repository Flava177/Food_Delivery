using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodDeliveries.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "126397c5-ad49-4e89-9831-925d1485979a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c35400-a249-40df-88f5-1f7ad15134b5");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuItemId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuItemId",
                table: "Orders",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MenuItems_MenuItemId",
                table: "Orders",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MenuItems_MenuItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MenuItemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "126397c5-ad49-4e89-9831-925d1485979a", null, "Administrator", "ADMINISTRATOR" },
                    { "18c35400-a249-40df-88f5-1f7ad15134b5", null, "Customer", "CUSTOMER" }
                });
        }
    }
}

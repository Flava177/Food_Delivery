using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodDeliveries.Migrations
{
    /// <inheritdoc />
    public partial class secondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e76b9ba-511c-491e-aff4-2ec6211737f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "521ac484-3fd3-47f2-a44b-50fbf9856c1a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "126397c5-ad49-4e89-9831-925d1485979a", null, "Administrator", "ADMINISTRATOR" },
                    { "18c35400-a249-40df-88f5-1f7ad15134b5", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "126397c5-ad49-4e89-9831-925d1485979a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c35400-a249-40df-88f5-1f7ad15134b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e76b9ba-511c-491e-aff4-2ec6211737f2", null, "Customer", "CUSTOMER" },
                    { "521ac484-3fd3-47f2-a44b-50fbf9856c1a", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}

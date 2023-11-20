using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AthenaResturantWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subCategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_subCategoryID",
                table: "Products",
                column: "subCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductID",
                table: "OrderLines",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductID",
                table: "OrderLines",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_subCategoryID",
                table: "Products",
                column: "subCategoryID",
                principalTable: "SubCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductID",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_subCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_subCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductID",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "subCategoryID",
                table: "Products");
        }
    }
}

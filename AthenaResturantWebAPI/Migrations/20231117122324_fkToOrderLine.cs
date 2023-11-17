using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AthenaResturantWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class fkToOrderLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderLineID",
                table: "Orders",
                column: "OrderLineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderLines_OrderLineID",
                table: "Orders",
                column: "OrderLineID",
                principalTable: "OrderLines",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderLines_OrderLineID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderLineID",
                table: "Orders");
        }
    }
}

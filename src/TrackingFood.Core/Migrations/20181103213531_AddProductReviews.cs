using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingFood.Core.Migrations
{
    public partial class AddProductReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemIdMenuItens",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuItemIdMenuItens",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MenuItemIdMenuItens",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdMenuItem",
                table: "OrderItems",
                column: "IdMenuItem");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItems_IdMenuItem",
                table: "OrderItems",
                column: "IdMenuItem",
                principalTable: "MenuItems",
                principalColumn: "IdMenuItens",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItems_IdMenuItem",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_IdMenuItem",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemIdMenuItens",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemIdMenuItens",
                table: "OrderItems",
                column: "MenuItemIdMenuItens");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemIdMenuItens",
                table: "OrderItems",
                column: "MenuItemIdMenuItens",
                principalTable: "MenuItems",
                principalColumn: "IdMenuItens",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

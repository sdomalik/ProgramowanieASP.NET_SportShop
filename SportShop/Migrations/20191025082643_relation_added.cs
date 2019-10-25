using Microsoft.EntityFrameworkCore.Migrations;

namespace SportShop.Migrations
{
    public partial class relation_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Products_ProductId",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_ProductId",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Manufacturers");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Manufacturers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_ProductId",
                table: "Manufacturers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Products_ProductId",
                table: "Manufacturers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

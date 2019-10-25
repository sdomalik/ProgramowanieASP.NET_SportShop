using Microsoft.EntityFrameworkCore.Migrations;

namespace SportShop.Migrations
{
    public partial class added_product_manufacturer_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Products_ProductId",
                table: "Manufacturers");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Manufacturers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Products_ProductId",
                table: "Manufacturers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Products_ProductId",
                table: "Manufacturers");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Manufacturers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Products_ProductId",
                table: "Manufacturers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

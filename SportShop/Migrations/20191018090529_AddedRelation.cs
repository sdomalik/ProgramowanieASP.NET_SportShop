using Microsoft.EntityFrameworkCore.Migrations;

namespace SportShop.Migrations
{
    public partial class AddedRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Manufacturers",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

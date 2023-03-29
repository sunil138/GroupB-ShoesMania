using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_PCategory.Migrations
{
    /// <inheritdoc />
    public partial class updatedCategoryField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsCategory_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsCategory_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductsCategory",
                principalColumn: "CategoryId");
        }
    }
}

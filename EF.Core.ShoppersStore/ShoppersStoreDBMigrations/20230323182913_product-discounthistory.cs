using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Core.ShoppersStore.ShoppersStoreDBMigrations
{
    public partial class productdiscounthistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DiscountHistories_ProductId",
                table: "DiscountHistories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountHistories_Products_ProductId",
                table: "DiscountHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountHistories_Products_ProductId",
                table: "DiscountHistories");

            migrationBuilder.DropIndex(
                name: "IX_DiscountHistories_ProductId",
                table: "DiscountHistories");
        }
    }
}

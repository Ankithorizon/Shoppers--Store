using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Core.ShoppersStore.ShoppersStoreDBMigrations
{
    public partial class paymentproductsell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BillRefCode",
                table: "ProductSells",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "ProductSells",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillRefCode",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSells_PaymentId",
                table: "ProductSells",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSells_Payments_PaymentId",
                table: "ProductSells",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSells_Payments_PaymentId",
                table: "ProductSells");

            migrationBuilder.DropIndex(
                name: "IX_ProductSells_PaymentId",
                table: "ProductSells");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "ProductSells");

            migrationBuilder.AlterColumn<string>(
                name: "BillRefCode",
                table: "ProductSells",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BillRefCode",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Core.ShoppersStore.ShoppersStoreDBMigrations
{
    public partial class paymentproductsellconnect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSells_Payments_PaymentId",
                table: "ProductSells");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "ProductSells",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSells_Payments_PaymentId",
                table: "ProductSells",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSells_Payments_PaymentId",
                table: "ProductSells");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "ProductSells",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSells_Payments_PaymentId",
                table: "ProductSells",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

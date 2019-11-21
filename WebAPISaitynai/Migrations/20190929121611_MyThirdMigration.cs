using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISaitynai.Migrations
{
    public partial class MyThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GoodsItemId",
                table: "InvoiceItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "ClientItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "InvoiceItemId",
                table: "ClientItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_GoodsItemId",
                table: "InvoiceItems",
                column: "GoodsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientItems_InvoiceItemId",
                table: "ClientItems",
                column: "InvoiceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientItems_InvoiceItems_InvoiceItemId",
                table: "ClientItems",
                column: "InvoiceItemId",
                principalTable: "InvoiceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_GoodsItems_GoodsItemId",
                table: "InvoiceItems",
                column: "GoodsItemId",
                principalTable: "GoodsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientItems_InvoiceItems_InvoiceItemId",
                table: "ClientItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_GoodsItems_GoodsItemId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_GoodsItemId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_ClientItems_InvoiceItemId",
                table: "ClientItems");

            migrationBuilder.DropColumn(
                name: "GoodsItemId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "ClientItems");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId",
                table: "ClientItems");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISaitynai.Migrations
{
    public partial class MySixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsItems_InvoiceItems_InvoiceItemId",
                table: "GoodsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ClientItems_ClientItemId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "GoodsItems");

            migrationBuilder.RenameColumn(
                name: "ClientItemId",
                table: "InvoiceItems",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_ClientItemId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_Client");

            migrationBuilder.RenameColumn(
                name: "InvoiceItemId",
                table: "GoodsItems",
                newName: "Invoice");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsItems_InvoiceItemId",
                table: "GoodsItems",
                newName: "IX_GoodsItems_Invoice");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsItems_InvoiceItems_Invoice",
                table: "GoodsItems",
                column: "Invoice",
                principalTable: "InvoiceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_ClientItems_Client",
                table: "InvoiceItems",
                column: "Client",
                principalTable: "ClientItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsItems_InvoiceItems_Invoice",
                table: "GoodsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ClientItems_Client",
                table: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "Client",
                table: "InvoiceItems",
                newName: "ClientItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_Client",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_ClientItemId");

            migrationBuilder.RenameColumn(
                name: "Invoice",
                table: "GoodsItems",
                newName: "InvoiceItemId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsItems_Invoice",
                table: "GoodsItems",
                newName: "IX_GoodsItems_InvoiceItemId");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "GoodsItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsItems_InvoiceItems_InvoiceItemId",
                table: "GoodsItems",
                column: "InvoiceItemId",
                principalTable: "InvoiceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_ClientItems_ClientItemId",
                table: "InvoiceItems",
                column: "ClientItemId",
                principalTable: "ClientItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

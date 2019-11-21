using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISaitynai.Migrations
{
    public partial class MyFourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientItems_InvoiceItems_InvoiceItemId",
                table: "ClientItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_GoodsItems_GoodsItemId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_ClientItems_InvoiceItemId",
                table: "ClientItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "ClientItems");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId",
                table: "ClientItems");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceItems",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "GoodsItemId",
                table: "InvoiceItems",
                newName: "ClientItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_GoodsItemId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_ClientItemId");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "GoodsItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "InvoiceItemId",
                table: "GoodsItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsItems_InvoiceItemId",
                table: "GoodsItems",
                column: "InvoiceItemId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsItems_InvoiceItems_InvoiceItemId",
                table: "GoodsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ClientItems_ClientItemId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_GoodsItems_InvoiceItemId",
                table: "GoodsItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "GoodsItems");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId",
                table: "GoodsItems");

            migrationBuilder.RenameColumn(
                name: "ClientItemId",
                table: "InvoiceItems",
                newName: "GoodsItemId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "InvoiceItems",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_ClientItemId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_GoodsItemId");

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
    }
}

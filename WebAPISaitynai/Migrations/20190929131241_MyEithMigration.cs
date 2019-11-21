using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPISaitynai.Migrations
{
    public partial class MyEithMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsItems_InvoiceItems_InvoiceItemId",
                table: "GoodsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ClientItems_ClientItemId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_ClientItemId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_GoodsItems_InvoiceItemId",
                table: "GoodsItems");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "GoodsItems");

            migrationBuilder.AlterColumn<int>(
                name: "ClientItemId",
                table: "InvoiceItems",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClientItemId1",
                table: "InvoiceItems",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceItemId",
                table: "GoodsItems",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InvoiceItemId1",
                table: "GoodsItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ClientItemId1",
                table: "InvoiceItems",
                column: "ClientItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsItems_InvoiceItemId1",
                table: "GoodsItems",
                column: "InvoiceItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsItems_InvoiceItems_InvoiceItemId1",
                table: "GoodsItems",
                column: "InvoiceItemId1",
                principalTable: "InvoiceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_ClientItems_ClientItemId1",
                table: "InvoiceItems",
                column: "ClientItemId1",
                principalTable: "ClientItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsItems_InvoiceItems_InvoiceItemId1",
                table: "GoodsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ClientItems_ClientItemId1",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_ClientItemId1",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_GoodsItems_InvoiceItemId1",
                table: "GoodsItems");

            migrationBuilder.DropColumn(
                name: "ClientItemId1",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId1",
                table: "GoodsItems");

            migrationBuilder.AlterColumn<long>(
                name: "ClientItemId",
                table: "InvoiceItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceItemId",
                table: "GoodsItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "GoodsItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ClientItemId",
                table: "InvoiceItems",
                column: "ClientItemId");

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
    }
}

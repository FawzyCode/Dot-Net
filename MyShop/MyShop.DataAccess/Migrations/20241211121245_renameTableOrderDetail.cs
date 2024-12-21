using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Web.Migrations
{
    /// <inheritdoc />
    public partial class renameTableOrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDtails_OrderHeaders_OrderHeaderId",
                table: "OrderDtails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDtails_Products_ProductId",
                table: "OrderDtails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDtails",
                table: "OrderDtails");

            migrationBuilder.RenameTable(
                name: "OrderDtails",
                newName: "OrderDetail");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDtails_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDtails_OrderHeaderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_OrderHeaders_OrderHeaderId",
                table: "OrderDetail",
                column: "OrderHeaderId",
                principalTable: "OrderHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_OrderHeaders_OrderHeaderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDtails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDtails",
                newName: "IX_OrderDtails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderHeaderId",
                table: "OrderDtails",
                newName: "IX_OrderDtails_OrderHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDtails",
                table: "OrderDtails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDtails_OrderHeaders_OrderHeaderId",
                table: "OrderDtails",
                column: "OrderHeaderId",
                principalTable: "OrderHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDtails_Products_ProductId",
                table: "OrderDtails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

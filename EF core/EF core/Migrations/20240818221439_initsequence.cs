using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_core.Migrations
{
    /// <inheritdoc />
    public partial class initsequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DeliveryOrder",
                startValue: 101L);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrder",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValueSql: "Next Value For DeliveryOrder");

            migrationBuilder.CreateTable(
                name: "Uniforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryOrder = table.Column<int>(type: "int", nullable: false, defaultValueSql: "Next Value For DeliveryOrder")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uniforms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uniforms");

            migrationBuilder.DropColumn(
                name: "DeliveryOrder",
                table: "Books");

            migrationBuilder.DropSequence(
                name: "DeliveryOrder");
        }
    }
}

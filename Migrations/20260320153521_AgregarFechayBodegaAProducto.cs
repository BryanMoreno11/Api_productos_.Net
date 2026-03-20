using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFechayBodegaAProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodegaId",
                table: "productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "productos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_productos_BodegaId",
                table: "productos",
                column: "BodegaId");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_bodegas_BodegaId",
                table: "productos",
                column: "BodegaId",
                principalTable: "bodegas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_bodegas_BodegaId",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_productos_BodegaId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "BodegaId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "productos");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Destruimos la llave primaria actual
            migrationBuilder.DropPrimaryKey(
                name: "PK_productos",
                table: "productos");
            // 2. Aniquilamos la columna UUID problemática
            migrationBuilder.DropColumn(
                name: "Id",
                table: "productos");
            // 3. Creamos la nueva columna como Entero y autoincremental (Identity)
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "productos",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            // 4. Volvemos a coronarla como llave primaria
            migrationBuilder.AddPrimaryKey(
                name: "PK_productos",
                table: "productos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Destruimos la llave primaria de la columna entera
            migrationBuilder.DropPrimaryKey(
                name: "PK_productos",
                table: "productos");
            // 2. Aniquilamos la nueva columna entera
            migrationBuilder.DropColumn(
                name: "Id",
                table: "productos");
            // 3. Recreamos la columna original UUID (Guid)
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "productos",
                type: "uuid", // El tipo nativo de Postgres
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")); 
            // 4. Coronamos al UUID como llave primaria otra vez
            migrationBuilder.AddPrimaryKey(
                name: "PK_productos",
                table: "productos",
                column: "Id");
                }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorGastosAPI.Migrations
{
    /// <inheritdoc />
    public partial class CambiarTipoCategoriaAgregarCampoMoneda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Categoria",
                table: "Transacciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Moneda",
                table: "Transacciones",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Moneda",
                table: "Transacciones");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Transacciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

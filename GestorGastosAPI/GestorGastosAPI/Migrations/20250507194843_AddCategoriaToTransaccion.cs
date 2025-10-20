using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorGastosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaToTransaccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Transacciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Transacciones");
        }
    }
}

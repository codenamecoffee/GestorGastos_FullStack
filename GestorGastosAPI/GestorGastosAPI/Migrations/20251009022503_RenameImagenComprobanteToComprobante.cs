using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorGastosAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameImagenComprobanteToComprobante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagenMimeType",
                table: "Transacciones",
                newName: "ComprobanteMimeType");

            migrationBuilder.RenameColumn(
                name: "ImagenComprobante",
                table: "Transacciones",
                newName: "Comprobante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComprobanteMimeType",
                table: "Transacciones",
                newName: "ImagenMimeType");

            migrationBuilder.RenameColumn(
                name: "Comprobante",
                table: "Transacciones",
                newName: "ImagenComprobante");
        }
    }
}

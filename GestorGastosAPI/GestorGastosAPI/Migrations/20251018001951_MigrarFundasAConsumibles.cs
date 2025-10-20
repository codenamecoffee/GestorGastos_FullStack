using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorGastosAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigrarFundasAConsumibles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Asumiendo que Fundas = 2 y Consumibles = 6(según el orden actual del enum)
            migrationBuilder.Sql("UPDATE Transacciones SET Categoria = 6 WHERE Categoria = 2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

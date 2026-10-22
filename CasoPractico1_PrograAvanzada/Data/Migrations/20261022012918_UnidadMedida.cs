using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasoPractico1_PrograAvanzada.Data.Migrations
{
    /// <inheritdoc />
    public partial class UnidadMedida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Productos_TipoVenta",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "TipoVenta",
                table: "Productos",
                newName: "UnidadMedida");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Productos_UnidadMedida",
                table: "Productos",
                sql: "[UnidadMedida] IN (1, 2, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Productos_UnidadMedida",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "UnidadMedida",
                table: "Productos",
                newName: "TipoVenta");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Productos_TipoVenta",
                table: "Productos",
                sql: "[TipoVenta] IN (1, 2)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Joint_Residential_Management.Migrations
{
    /// <inheritdoc />
    public partial class fixingForeignKeyResidente2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_residente",
                table: "ReporteAnomalias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReporteAnomalias_Id_residente",
                table: "ReporteAnomalias",
                column: "Id_residente");

            migrationBuilder.AddForeignKey(
                name: "FK_ReporteAnomalias_Residentes_Id_residente",
                table: "ReporteAnomalias",
                column: "Id_residente",
                principalTable: "Residentes",
                principalColumn: "Id_residente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReporteAnomalias_Residentes_Id_residente",
                table: "ReporteAnomalias");

            migrationBuilder.DropIndex(
                name: "IX_ReporteAnomalias_Id_residente",
                table: "ReporteAnomalias");

            migrationBuilder.DropColumn(
                name: "Id_residente",
                table: "ReporteAnomalias");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Joint_Residential_Management.Migrations
{
    /// <inheritdoc />
    public partial class changerelationshipReporteAnomaliawithEstadoAnomalia0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReporteAnomalias",
                columns: table => new
                {
                    Id_ReporteA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DescripcionAnomalia = table.Column<string>(type: "longtext", nullable: false),
                    FechaReporteAnomalia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FotoAnomalia = table.Column<string>(type: "longtext", nullable: false),
                    TipoAnomalia = table.Column<string>(type: "longtext", nullable: false),
                    AsuntoAnomalia = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteAnomalias", x => x.Id_ReporteA);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Roles = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_User);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadosAnomalia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Estado = table.Column<string>(type: "longtext", nullable: false),
                    fechaEstado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id_ReporteA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosAnomalia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadosAnomalia_ReporteAnomalias_Id_ReporteA",
                        column: x => x.Id_ReporteA,
                        principalTable: "ReporteAnomalias",
                        principalColumn: "Id_ReporteA",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Residentes",
                columns: table => new
                {
                    Id_residente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_residente = table.Column<string>(type: "longtext", nullable: false),
                    Num_apartamento = table.Column<string>(type: "longtext", nullable: false),
                    Num_telefono = table.Column<string>(type: "longtext", nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residentes", x => x.Id_residente);
                    table.ForeignKey(
                        name: "FK_Residentes_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosAnomalia_Id_ReporteA",
                table: "EstadosAnomalia",
                column: "Id_ReporteA");

            migrationBuilder.CreateIndex(
                name: "IX_Residentes_Id_User",
                table: "Residentes",
                column: "Id_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosAnomalia");

            migrationBuilder.DropTable(
                name: "Residentes");

            migrationBuilder.DropTable(
                name: "ReporteAnomalias");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

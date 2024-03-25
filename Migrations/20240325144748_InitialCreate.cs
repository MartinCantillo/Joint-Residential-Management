using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Joint_Residential_Management.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DescripcionAnomalia = table.Column<string>(type: "longtext", nullable: false),
                    FechaReporteAnomalia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FotoAnomalia = table.Column<string>(type: "longtext", nullable: false),
                    TipoAnomalia = table.Column<string>(type: "longtext", nullable: false),
                    AsuntoAnomalia = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteAnomalias", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_User);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoAnomalia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre_Estado = table.Column<string>(type: "longtext", nullable: false),
                    fechaEstado = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAnomalia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoAnomalia_ReporteAnomalias_Id",
                        column: x => x.Id,
                        principalTable: "ReporteAnomalias",
                        principalColumn: "Id",
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

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id_Roles = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: false),
                    UserId_User = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id_Roles);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId_User",
                        column: x => x.UserId_User,
                        principalTable: "Users",
                        principalColumn: "Id_User");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Residentes_Id_User",
                table: "Residentes",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId_User",
                table: "Roles",
                column: "UserId_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadoAnomalia");

            migrationBuilder.DropTable(
                name: "Residentes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ReporteAnomalias");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

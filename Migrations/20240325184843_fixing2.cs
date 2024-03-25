using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Joint_Residential_Management.Migrations
{
    /// <inheritdoc />
    public partial class fixing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_Id_Roles",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "Id_Roles",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Roles",
                table: "Roles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Roles",
                table: "Users",
                column: "Id_Roles");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Id_Roles",
                table: "Users",
                column: "Id_Roles",
                principalTable: "Roles",
                principalColumn: "Id_Roles",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Id_Roles",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id_Roles",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id_Roles",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Roles",
                table: "Roles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_Id_Roles",
                table: "Roles",
                column: "Id_Roles",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

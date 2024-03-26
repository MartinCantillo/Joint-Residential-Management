using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Joint_Residential_Management.Migrations
{
    /// <inheritdoc />
    public partial class IsActivoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActivo",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivo",
                table: "Users");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewValueMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "Works",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHours",
                table: "Works",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "Works");
        }
    }
}

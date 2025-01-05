using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCaloriesBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaloriesBalance",
                table: "Dashboard",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesBalance",
                table: "Dashboard");
        }
    }
}

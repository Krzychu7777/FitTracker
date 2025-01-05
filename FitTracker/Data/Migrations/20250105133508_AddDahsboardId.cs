using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDahsboardId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DashboardId",
                table: "MealsList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardId",
                table: "ExercisesList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCalories = table.Column<int>(type: "int", nullable: false),
                    TotalExercises = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboard", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealsList_DashboardId",
                table: "MealsList",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesList_DashboardId",
                table: "ExercisesList",
                column: "DashboardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesList_Dashboard_DashboardId",
                table: "ExercisesList",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealsList_Dashboard_DashboardId",
                table: "MealsList",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesList_Dashboard_DashboardId",
                table: "ExercisesList");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsList_Dashboard_DashboardId",
                table: "MealsList");

            migrationBuilder.DropTable(
                name: "Dashboard");

            migrationBuilder.DropIndex(
                name: "IX_MealsList_DashboardId",
                table: "MealsList");

            migrationBuilder.DropIndex(
                name: "IX_ExercisesList_DashboardId",
                table: "ExercisesList");

            migrationBuilder.DropColumn(
                name: "DashboardId",
                table: "MealsList");

            migrationBuilder.DropColumn(
                name: "DashboardId",
                table: "ExercisesList");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersToMealsLIstAndExerciseList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MealsList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExercisesList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealsList_UserId",
                table: "MealsList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesList_UserId",
                table: "ExercisesList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesList_AspNetUsers_UserId",
                table: "ExercisesList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealsList_AspNetUsers_UserId",
                table: "MealsList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesList_AspNetUsers_UserId",
                table: "ExercisesList");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsList_AspNetUsers_UserId",
                table: "MealsList");

            migrationBuilder.DropIndex(
                name: "IX_MealsList_UserId",
                table: "MealsList");

            migrationBuilder.DropIndex(
                name: "IX_ExercisesList_UserId",
                table: "ExercisesList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MealsList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExercisesList");
        }
    }
}

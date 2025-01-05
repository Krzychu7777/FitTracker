using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "MealsList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "ExercisesList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCalories = table.Column<int>(type: "int", nullable: false),
                    TotalExercises = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealsList_HistoryId",
                table: "MealsList",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesList_HistoryId",
                table: "ExercisesList",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesList_History_HistoryId",
                table: "ExercisesList",
                column: "HistoryId",
                principalTable: "History",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealsList_History_HistoryId",
                table: "MealsList",
                column: "HistoryId",
                principalTable: "History",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesList_History_HistoryId",
                table: "ExercisesList");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsList_History_HistoryId",
                table: "MealsList");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropIndex(
                name: "IX_MealsList_HistoryId",
                table: "MealsList");

            migrationBuilder.DropIndex(
                name: "IX_ExercisesList_HistoryId",
                table: "ExercisesList");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "MealsList");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "ExercisesList");
        }
    }
}

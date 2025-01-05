namespace FitTracker.Models
{
    public class Dashboard
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int TotalCalories { get; set; }
        public int TotalExercises { get; set; }
        public int TotalBurnedCalories { get; set; }
        public int CaloriesBalance { get; set; }
        public IEnumerable<MealsList> Meals { get; set; } = new List<MealsList>();
        public IEnumerable<ExercisesList> Exercises { get; set; } = new List<ExercisesList>();
    }
}

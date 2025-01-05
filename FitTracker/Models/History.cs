namespace FitTracker.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<MealsList> Meals { get; set; } = new List<MealsList>();
        public List<ExercisesList> Exercises { get; set; } = new List<ExercisesList>();
        public int TotalCalories { get; set; }
        public int TotalExercises { get; set; }
        public int CaloriesBalance { get; set; }
        public int TotalBurnedCalories { get; set; }
    }
}

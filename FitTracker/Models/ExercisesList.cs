using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FitTracker.Models
{
    public class ExercisesList
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa ćwiczenia")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Spalone kalorie")]
        public int BurnedCalories { get; set; }

        [Required]
        [Display(Name = "Data wykonania ćwiczenia")]
        public DateTime TrainingAt { get; set; }

        public string? UserId { get; set; }

        public IdentityUser? User { get; set; }

    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FitTracker.Models
{
    public class MealsList
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa posiłku")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Kalorie")]
        public int Calories { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        public string? UserId { get; set; }

        public IdentityUser? User { get; set; }

    }
}

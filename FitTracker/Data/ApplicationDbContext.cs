using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FitTracker.Models;

namespace FitTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FitTracker.Models.MealsList> MealsList { get; set; } = default!;
        public DbSet<FitTracker.Models.ExercisesList> ExercisesList { get; set; } = default!;
        public DbSet<FitTracker.Models.Dashboard> Dashboard { get; set; } = default!;
        public DbSet<FitTracker.Models.History> History { get; set; } = default!;
    }
}

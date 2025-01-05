using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitTracker.Data;
using FitTracker.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FitTracker.Controllers
{
    [Authorize]
    public class HistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Histories
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            DateTime start = startDate ?? DateTime.Today.AddDays(-7);
            DateTime end = endDate ?? DateTime.Today;

            List<MealsList> meals = await _context.MealsList
                .Where(m => m.UserId == userId && m.Date.Date >= start && m.Date.Date <= end)
                .ToListAsync();

            List<ExercisesList> exercises = await _context.ExercisesList
                .Where(e => e.UserId == userId && e.TrainingAt.Date >= start && e.TrainingAt.Date <= end)
                .ToListAsync();

            int totalCaloriesToday = meals.Sum(m => m.Calories);
            int totalBurnedCalories = exercises.Sum(m => m.BurnedCalories);

            int calorieBalance = totalCaloriesToday - totalBurnedCalories;

            // Stwórz model
            History model = new History
            {
                Id = 1, 
                StartDate = start,
                EndDate = end,
                Meals = meals,
                Exercises = exercises,
                TotalCalories = totalCaloriesToday,
                TotalBurnedCalories = totalBurnedCalories,
                CaloriesBalance = calorieBalance,
                TotalExercises = exercises.Count
            };

            return View(model);
        }
        
    }
}

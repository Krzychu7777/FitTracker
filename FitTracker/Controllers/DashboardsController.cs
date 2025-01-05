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
    public class DashboardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dashboards
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTime today = DateTime.Today;

            List<MealsList> meals = await _context.MealsList
                .Where(m => m.UserId == userId && m.Date.Date == today)
                .ToListAsync();

            List<ExercisesList> exercises = await _context.ExercisesList
                .Where(e => e.UserId == userId && e.TrainingAt.Date == today)
                .ToListAsync();

            int totalCaloriesToday = meals.Sum(m => m.Calories);
            int totalExercisesToday = exercises.Count;
            int totalBurnedCalories = exercises.Sum(m => m.BurnedCalories);

            int calorieBalance = totalCaloriesToday - totalBurnedCalories;

            Dashboard model = new Dashboard
            {
                UserName = User.Identity.Name ?? "Guest",
                TotalCalories = totalCaloriesToday,
                TotalExercises = totalExercisesToday,
                TotalBurnedCalories = totalBurnedCalories,
                CaloriesBalance = calorieBalance,
                Meals = meals,
                Exercises = exercises
            };

            return View(model);
        }
    }
}

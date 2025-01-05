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
    public class ExercisesListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExercisesListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExercisesLists
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _context.ExercisesList.Include(s => s.User).Where(s => s.UserId == userId).ToListAsync());
        }

        // GET: ExercisesLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisesList = await _context.ExercisesList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercisesList == null)
            {
                return NotFound();
            }

            return View(exercisesList);
        }

        // GET: ExercisesLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExercisesLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BurnedCalories,TrainingAt")] ExercisesList exercisesList)
        {
            exercisesList.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _context.Add(exercisesList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercisesList);
        }

        // GET: ExercisesLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisesList = await _context.ExercisesList.FindAsync(id);
            if (exercisesList == null)
            {
                return NotFound();
            }
            return View(exercisesList);
        }

        // POST: ExercisesLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BurnedCalories,TrainingAt")] ExercisesList exercisesList)
        {
            if (id != exercisesList.Id)
            {
                return NotFound();
            }

            var existingExercise = await _context.ExercisesList.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (existingExercise == null)
            {
                return NotFound();
            }

            exercisesList.UserId = existingExercise.UserId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercisesList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercisesListExists(exercisesList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exercisesList);
        }

        // GET: ExercisesLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisesList = await _context.ExercisesList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercisesList == null)
            {
                return NotFound();
            }

            return View(exercisesList);
        }

        // POST: ExercisesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercisesList = await _context.ExercisesList.FindAsync(id);
            if (exercisesList != null)
            {
                _context.ExercisesList.Remove(exercisesList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercisesListExists(int id)
        {
            return _context.ExercisesList.Any(e => e.Id == id);
        }
    }
}

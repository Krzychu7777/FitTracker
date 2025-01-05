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
    public class MealsListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealsListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MealsLists
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _context.MealsList.Include(s => s.User).Where(s => s.UserId == userId).ToListAsync());
        }

        // GET: MealsLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealsList = await _context.MealsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealsList == null)
            {
                return NotFound();
            }

            return View(mealsList);
        }

        // GET: MealsLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealsLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Calories,Description,Date")] MealsList mealsList)
        {
            mealsList.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _context.Add(mealsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealsList);
        }

        // GET: MealsLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealsList = await _context.MealsList.FindAsync(id);
            if (mealsList == null)
            {
                return NotFound();
            }
            return View(mealsList);
        }

        // POST: MealsLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Calories,Description,Date")] MealsList mealsList)
        {
            if (id != mealsList.Id)
            {
                return NotFound();
            }

            var existingMeal = await _context.MealsList.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (existingMeal == null)
            {
                return NotFound();
            }

            mealsList.UserId = existingMeal.UserId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealsList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealsListExists(mealsList.Id))
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
            return View(mealsList);
        }

        // GET: MealsLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealsList = await _context.MealsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealsList == null)
            {
                return NotFound();
            }

            return View(mealsList);
        }

        // POST: MealsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealsList = await _context.MealsList.FindAsync(id);
            if (mealsList != null)
            {
                _context.MealsList.Remove(mealsList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealsListExists(int id)
        {
            return _context.MealsList.Any(e => e.Id == id);
        }
    }
}

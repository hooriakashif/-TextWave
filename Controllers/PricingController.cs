using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TextWave.Data;    // This links to your Database
using TextWave.Models;  // This links to your PricingPlan model

namespace TextWave.Controllers
{
    public class PricingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PricingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pricing
        public async Task<IActionResult> Index()
        {
            // This will now work because of Step 1
            var plans = await _context.PricingPlans.ToListAsync();
            return View(plans);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PricingPlan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", await _context.PricingPlans.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PricingPlan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Update(plan);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var plan = await _context.PricingPlans.FindAsync(id);
            if (plan != null)
            {
                _context.PricingPlans.Remove(plan);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
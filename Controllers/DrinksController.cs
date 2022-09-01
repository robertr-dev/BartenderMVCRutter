using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BartenderMVCRutter.Data;
using BartenderMVCRutter.Models;

namespace BartenderMVCRutter.Controllers
{
    public class DrinksController : Controller
    {
        private readonly BartenderMVCRutterContext _context;

        public DrinksController(BartenderMVCRutterContext context)
        {
            _context = context;
        }

        // GET: Drinks
        public async Task<IActionResult> Index()
        {
              return _context.Drink != null ? 
                          View(await _context.Drink.ToListAsync()) :
                          Problem("Entity set 'BartenderMVCRutterContext.Drink'  is null.");
        }

        // GET: Drinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .FirstOrDefaultAsync(m => m.DrinkID == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // GET: Drinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrinkID,DrinkName,DrinkDesc,DrinkPrice")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drink);
        }

        // GET: Drinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrinkID,DrinkName,DrinkDesc,DrinkPrice")] Drink drink)
        {
            if (id != drink.DrinkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkExists(drink.DrinkID))
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
            return View(drink);
        }

        // GET: Drinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .FirstOrDefaultAsync(m => m.DrinkID == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drink == null)
            {
                return Problem("Entity set 'BartenderMVCRutterContext.Drink'  is null.");
            }
            var drink = await _context.Drink.FindAsync(id);
            if (drink != null)
            {
                _context.Drink.Remove(drink);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinkExists(int id)
        {
          return (_context.Drink?.Any(e => e.DrinkID == id)).GetValueOrDefault();
        }
    }
}

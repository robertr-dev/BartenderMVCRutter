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
    public class HomeController : Controller
    {
        private readonly BartenderMVCRutterContext _context;

        public HomeController(BartenderMVCRutterContext context)
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

        [HttpPost]
        public async Task<IActionResult> Index(String drink)
        {
            if (!TempData.ContainsKey(drink))
            {
                TempData[drink] = 1;
                TempData.Keep(drink);
            }
            else
            {
                TempData[drink] = (int)TempData[drink] + 1;
                TempData.Keep(drink);
            }
            Console.WriteLine($"{drink} was added to cart and has a quantity of {TempData[drink]}");

            List<String> currentKeys = new(TempData.Keys);
            foreach(var item in currentKeys)
            {
                TempData.Keep(item);
            }

            return _context.Drink != null ?
                        View(await _context.Drink.ToListAsync()) :
                        Problem("Entity set 'BartenderMVCRutterContext.Drink'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            TempData.Clear();
            Console.WriteLine("Cart was cleared.");

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Checkout()
        {
            return View();
        }
    }
}

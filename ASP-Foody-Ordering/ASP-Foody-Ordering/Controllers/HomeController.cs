using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Foody_Ordering.Data;
using ASP_Foody_Ordering.Models;

namespace ASP_Foody_Ordering.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Monans.OrderByDescending(m => m.LuotXem).Take(9);
            return View(await applicationDbContext.ToListAsync());
        }
        //GET:Menu
        public async Task<IActionResult> Menu()
        {
            var applicationDbContext = _context.Monans.Include(m => m.MaDmNavigation);
            return View(await applicationDbContext.ToListAsync());
        }
        //GET:About
        public async Task<IActionResult> About()
        {
            return View();
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Monans
                .Include(m => m.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaMa == id);

            if (monan.LuotXem == null)
                monan.LuotXem = 1;
            else
                monan.LuotXem += 1;

            try
            {
                _context.Update(monan);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonanExists(monan.MaMa))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        private bool MonanExists(int id)
        {
            return _context.Monans.Any(e => e.MaMa == id);
        }
    }
}

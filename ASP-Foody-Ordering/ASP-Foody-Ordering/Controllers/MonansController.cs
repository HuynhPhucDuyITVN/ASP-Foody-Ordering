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
    public class MonansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Monans.Include(m => m.MaDmNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Monans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Monans
                .Include(m => m.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaMa == id);
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        // GET: Monans/Create
        public IActionResult Create()
        {
            ViewData["MaDm"] = new SelectList(_context.Danhmucs, "MaDm", "Ten");
            return View();
        }

        // POST: Monans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMa,Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDm,LuotXem,LuotMua")] Monan monan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDm"] = new SelectList(_context.Danhmucs, "MaDm", "Ten", monan.MaDm);
            return View(monan);
        }

        // GET: Monans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Monans.FindAsync(id);
            if (monan == null)
            {
                return NotFound();
            }
            ViewData["MaDm"] = new SelectList(_context.Danhmucs, "MaDm", "Ten", monan.MaDm);
            return View(monan);
        }

        // POST: Monans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaMa,Ten,GiaGoc,GiaBan,MoTa,HinhAnh,MaDm,LuotXem,LuotMua")] Monan monan)
        {
            if (id != monan.MaMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDm"] = new SelectList(_context.Danhmucs, "MaDm", "Ten", monan.MaDm);
            return View(monan);
        }

        // GET: Monans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Monans
                .Include(m => m.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaMa == id);
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        // POST: Monans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monan = await _context.Monans.FindAsync(id);
            _context.Monans.Remove(monan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonanExists(int id)
        {
            return _context.Monans.Any(e => e.MaMa == id);
        }
    }
}

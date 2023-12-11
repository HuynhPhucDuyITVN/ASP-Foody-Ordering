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
    public class CthoadonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CthoadonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cthoadons
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cthoadons.Include(c => c.MaHdNavigation).Include(c => c.MaMaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cthoadons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthoadon = await _context.Cthoadons
                .Include(c => c.MaHdNavigation)
                .Include(c => c.MaMaNavigation)
                .FirstOrDefaultAsync(m => m.MaCthd == id);
            if (cthoadon == null)
            {
                return NotFound();
            }

            return View(cthoadon);
        }

        // GET: Cthoadons/Create
        public IActionResult Create()
        {
            ViewData["MaHd"] = new SelectList(_context.Hoadons, "MaHd", "MaHd");
            ViewData["MaMa"] = new SelectList(_context.Monans, "MaMa", "Ten");
            return View();
        }

        // POST: Cthoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCthd,MaHd,MaMa,DonGia,SoLuong,ThanhTien")] Cthoadon cthoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cthoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHd"] = new SelectList(_context.Hoadons, "MaHd", "MaHd", cthoadon.MaHd);
            ViewData["MaMa"] = new SelectList(_context.Monans, "MaMa", "Ten", cthoadon.MaMa);
            return View(cthoadon);
        }

        // GET: Cthoadons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthoadon = await _context.Cthoadons.FindAsync(id);
            if (cthoadon == null)
            {
                return NotFound();
            }
            ViewData["MaHd"] = new SelectList(_context.Hoadons, "MaHd", "MaHd", cthoadon.MaHd);
            ViewData["MaMa"] = new SelectList(_context.Monans, "MaMa", "Ten", cthoadon.MaMa);
            return View(cthoadon);
        }

        // POST: Cthoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCthd,MaHd,MaMa,DonGia,SoLuong,ThanhTien")] Cthoadon cthoadon)
        {
            if (id != cthoadon.MaCthd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cthoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CthoadonExists(cthoadon.MaCthd))
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
            ViewData["MaHd"] = new SelectList(_context.Hoadons, "MaHd", "MaHd", cthoadon.MaHd);
            ViewData["MaMa"] = new SelectList(_context.Monans, "MaMa", "Ten", cthoadon.MaMa);
            return View(cthoadon);
        }

        private bool CthoadonExists(int id)
        {
            return _context.Cthoadons.Any(e => e.MaCthd == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Foody_Ordering.Data;
using ASP_Foody_Ordering.Models;
using Microsoft.AspNetCore.Identity;

namespace ASP_Foody_Ordering.Controllers
{
    public class TaikhoansController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Taikhoan> _passwordHasher;

        public TaikhoansController(ApplicationDbContext context, IPasswordHasher<Taikhoan> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // GET: Taikhoans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taikhoans.ToListAsync());
        }

        // GET: Taikhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans
                .FirstOrDefaultAsync(m => m.MaTk == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // GET: Taikhoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taikhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTk,Ten,DienThoai,Email,MatKhau,QuyenHan,TrangThai")] Taikhoan taikhoan)
        {
            TempData["ErrorMessage"] = "";
            var tk = new Taikhoan();
            if (_context.Taikhoans.FirstOrDefault(m => m.Email == taikhoan.Email) == null)
            {
                if (ModelState.IsValid)
                {
                    taikhoan.MatKhau = _passwordHasher.HashPassword(taikhoan, taikhoan.MatKhau);
                    _context.Add(taikhoan);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(taikhoan);
            }
            else
            {
                TempData["ErrorMessage"] = "Email đã đăng ký xin vui lòng sử dụng email khác!!!";
                return RedirectToAction(nameof(Create));
            }
            
        }

        // GET: Taikhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }
            return View(taikhoan);
        }

        // POST: Taikhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTk,Ten,DienThoai,Email,MatKhau,QuyenHan,TrangThai")] Taikhoan taikhoan)
        {
            if (id != taikhoan.MaTk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taikhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaikhoanExists(taikhoan.MaTk))
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
            return View(taikhoan);
        }
        private bool TaikhoanExists(int id)
        {
            return _context.Taikhoans.Any(e => e.MaTk == id);
        }



        public async Task<IActionResult> DoiMK(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }
            return View(taikhoan);
        }
        [HttpPost]
        public async Task<IActionResult> DoiMK(int? id, string matkhaucu, string matkhaumoi, string xacnhanmatkhau)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }
            else
            {
                if (_passwordHasher.VerifyHashedPassword(taikhoan, taikhoan.MatKhau, matkhaucu)
                == PasswordVerificationResult.Success)
                {
                    if (matkhaumoi == xacnhanmatkhau)
                    {
                        try
                        {
                            taikhoan.MatKhau = _passwordHasher.HashPassword(taikhoan, matkhaumoi);
                            _context.Update(taikhoan);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!TaikhoanExists(taikhoan.MaTk))
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
                    else
                    {
                        TempData["doimk"] = "Xác nhận mật khẩu không khớp";
                        return RedirectToAction(nameof(DoiMK));
                    }

                }
                else
                {
                    TempData["doimk"] = "Mật khẩu cũ không chính xác vui lòng nhập lại";
                    return RedirectToAction(nameof(DoiMK));
                }
            }
            return View(taikhoan);
        }
    }
}

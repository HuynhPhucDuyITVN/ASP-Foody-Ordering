﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Foody_Ordering.Data;
using ASP_Foody_Ordering.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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

        // Đọc danh sách CartItem từ session
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString("shopcart");
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        // Lưu danh sách CartItem trong giỏ hàng vào session
        void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString("shopcart", jsoncart);
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove("shopcart");
        }

        // Cho hàng vào giỏ
        public async Task<IActionResult> AddToCart(int id)
        {
            var monan = await _context.Monans
                .FirstOrDefaultAsync(m => m.MaMa == id);
            if (monan == null)
            {
                return NotFound("Sản phẩm không tồn tại");
            }
            var cart = GetCartItems();
            var item = cart.Find(p => p.Monan.MaMa == id);
            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem() { Monan = monan, SoLuong = 1 });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }
        // Chuyển đến view xem giỏ hàng
        public IActionResult ViewCart()
        {
            return View(GetCartItems());
        }
        //Xóa một mặt hàng trong giỏ
        public IActionResult RemoveItem(int id)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.Monan.MaMa == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }
        //Cập nhật số lượng
        public IActionResult UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.Monan.MaMa == id);
            if (item != null)
            {
                item.SoLuong = quantity;
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        //create funtion fill ten 
        public async Task<IActionResult> LocTheoTen(string keyword)
        {
            var monan = _context.Monans.Where(p => p.Ten.Contains(keyword));
            return View(await monan.ToListAsync());
        }

        private bool MonanExists(int id)
        {
            return _context.Monans.Any(e => e.MaMa == id);
        }
    }
}

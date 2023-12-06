using System;
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
        //GET: Lấy số hàng trong giỏ
        void GetInfo()
        {
            // So luong hang trong gio
            ViewData["soluong"] = GetCartItems().Count;

            // Danh sach danh muc doc tu db
            ViewBag.danhmuc = _context.Danhmucs.ToList();
        }
        // GET: Home
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Monans.OrderByDescending(m => m.LuotXem).Take(9);
            return View(await applicationDbContext.ToListAsync());
        }
        //GET:Menu
        public async Task<IActionResult> Menu()
        {
            GetInfo();
            var applicationDbContext = _context.Monans.Include(m => m.MaDmNavigation);
            return View(await applicationDbContext.ToListAsync());
        }
        //GET:About
        public async Task<IActionResult> About()
        {
            GetInfo();
            return View();
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            GetInfo();
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
            GetInfo();
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

        public IActionResult CheckOut()
        {
            GetInfo();
            return View(GetCartItems());
        }

        //create funtion fill ten 
        public async Task<IActionResult> LocTheoTen(string keyword)
        {
            GetInfo();
            var monan = _context.Monans.Where(p => p.Ten.Contains(keyword));
            return View(await monan.ToListAsync());
        }

        private bool MonanExists(int id)
        {
            return _context.Monans.Any(e => e.MaMa == id);
        }

        public async Task<IActionResult> CreateBill(string hoten, string email, string dienthoai, string diachi, string phuongxa, string quanhuyen, string tinhthanh)
        {
            GetInfo();
            //luu tai khoan
            Taikhoan tk = new Taikhoan();
            tk.Ten = hoten;
            tk.Email = email;
            tk.DienThoai = dienthoai;
            _context.Add(tk);
            await _context.SaveChangesAsync();
            //luu dia chi
            Diachi dc = new Diachi();
            dc.MaTk = tk.MaTk;
            dc.DiaChi = diachi;
            dc.PhuongXa = phuongxa;
            dc.QuanHuyen = quanhuyen;
            dc.TinhThanh = tinhthanh;
            _context.Add(dc);
            await _context.SaveChangesAsync();
            //luu hoa don
            Hoadon hd = new Hoadon();
            hd.MaTk = tk.MaTk;
            hd.Ngay = DateTime.Now;

            _context.Add(hd);
            await _context.SaveChangesAsync();
            //luu cac chi tiet hoa don
            var cart = GetCartItems();
            int thanhtien = 0;
            int tongtien = 0;
            foreach (var i in cart)
            {
                var ct = new Cthoadon();
                ct.MaHd = hd.MaHd;
                ct.MaMa = i.Monan.MaMa;
                thanhtien = i.Monan.GiaBan * i.SoLuong;
                tongtien += thanhtien;
                ct.DonGia = i.Monan.GiaBan;
                ct.SoLuong = (short)i.SoLuong;
                ct.ThanhTien = thanhtien;
                if (i.Monan.LuotMua == null)
                    i.Monan.LuotMua = 1;
                else
                    i.Monan.LuotMua += 1;
                _context.Add(ct);
            }
            await _context.SaveChangesAsync();
            //cap nhat tong tien hoa don
            hd.TongTien = tongtien;
            _context.Update(hd);
            await _context.SaveChangesAsync();
            //xoa gio hang
            ClearCart();

            return View(hd);
        }
    }
}

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
using Microsoft.AspNetCore.Identity;

namespace ASP_Foody_Ordering.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Taikhoan> _passwordHasher;

        public HomeController(ApplicationDbContext context, IPasswordHasher<Taikhoan> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        //GET: Lấy số hàng trong giỏ
        public void GetInfo()
        {
            // So luong hang trong gio
            ViewData["soluong"] = GetCartItems().Count;

            // Danh sach danh muc doc tu db
            ViewBag.danhmuc = _context.Danhmucs.Where(dm => dm.TrangThai == 1).ToList();
            //Danh sach mon an theo luot mua
            ViewBag.luotmua = _context.Monans.OrderByDescending(m => m.LuotMua).Where(m => m.MaDmNavigation.TrangThai == 1).Take(6).ToList();
            //Taikhoan luu trong session
            if (HttpContext.Session.GetString("taikhoan") != "")
            {
                ViewBag.taikhoan = _context.Taikhoans.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("taikhoan"));
            }
        }
        // GET: Home
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Monans.OrderByDescending(m => m.LuotXem).Where(m => m.MaDmNavigation.TrangThai == 1).Take(6);
            return View(await applicationDbContext.ToListAsync());
        }
        //GET:Menu
        public async Task<IActionResult> Menu()
        {
            GetInfo();
            var applicationDbContext = _context.Monans.Include(m => m.MaDmNavigation).Where(m => m.MaDmNavigation.TrangThai == 1);
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
        public List<CartItem> GetCartItems()
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
            Taikhoan tk = ViewBag.taikhoan;
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
                var ma = _context.Monans.FirstOrDefault(m => m.MaMa == i.Monan.MaMa);
                ma.LuotMua = i.Monan.LuotMua;
                try
                {
                    _context.Update(ma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonanExists(ma.MaMa))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

        public async Task<IActionResult> MonAnTheoDanhMuc(int id)
        {
            GetInfo();
            var applicationDbContext = _context.Monans.Where(m => m.MaDm == id);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Login()
        {
            GetInfo();
            return View();
        }

        public IActionResult Register()
        {
            GetInfo();
            return View();
        }
        [HttpPost]
        public IActionResult Register(string email, string ten, string sdt, string matkhau)
        {
            var tk = new Taikhoan();
            if (_context.Taikhoans.FirstOrDefault(m => m.Email == email) == null)
            {
                tk.Email = email;
                tk.Ten = ten;
                tk.DienThoai = sdt;
                tk.MatKhau = _passwordHasher.HashPassword(tk, matkhau);
                _context.Add(tk);
                _context.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            else
            {
                TempData["ErrorMessage"] = "Email đã đăng ký xin vui lòng sử dụng email khác!!!";
                return RedirectToAction(nameof(Register));
            }

        }
        [HttpPost]
        public IActionResult Login(string email, string matkhau)
        {
            var tk = _context.Taikhoans.FirstOrDefault(m => m.Email == email);
            if (tk != null &&
                _passwordHasher.VerifyHashedPassword(tk, tk.MatKhau, matkhau)
                == PasswordVerificationResult.Success)
            {
                HttpContext.Session.SetString("taikhoan", tk.Email);
                if (tk.QuyenHan == 1 && tk.TrangThai == 1)
                    return RedirectToAction(nameof(Admin));
                else if (tk.QuyenHan == 0 && tk.TrangThai == 1)
                    return RedirectToAction(nameof(InfoTaiKhoan));
                else
                {
                    TempData["ErrorLogin"] = "Tài khoản đã bị khóa xin vui lòng liên hệ admin để mở khóa lại tài khoản!!!";
                    return RedirectToAction(nameof(Login));
                }
            }
            TempData["ErrorLogin"] = "Email hoặc mật khẩu không đúng xin vui lòng kiểm tra lại!!!";
            return RedirectToAction(nameof(Login));

        }
        public IActionResult InfoTaiKhoan()
        {
            GetInfo();
            return View();
        }
        public IActionResult Admin()
        {
            GetInfo();
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("taikhoan", "");
            GetInfo();
            return RedirectToAction(nameof(Index));
        }

        // GET: Taikhoans/Edit/5
        public async Task<IActionResult> EditTK(int? id)
        {
            GetInfo();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTK(int id, [Bind("MaTk,Ten,DienThoai,Email,MatKhau,QuyenHan,TrangThai")] Taikhoan taikhoan)
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
                HttpContext.Session.SetString("taikhoan", "");
                return RedirectToAction(nameof(Login));
            }
            return View(taikhoan);
        }
        private bool TaikhoanExists(int id)
        {
            return _context.Taikhoans.Any(e => e.MaTk == id);
        }

        public async Task<IActionResult> DoiMK(int? id)
        {
            GetInfo();
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
        public async Task<IActionResult> Hoadon(int? id)
        {
            GetInfo();
            var applicationDbContext = _context.Hoadons.Include(h => h.MaTkNavigation).Where(h=>h.MaTkNavigation.MaTk==id);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Chitiethoadon(int? id)
        {
            GetInfo();
            var applicationDbContext = _context.Cthoadons.Include(h => h.MaHdNavigation).Where(h => h.MaHdNavigation.MaHd == id);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> DoiMK(int? id, string matkhaucu, string matkhaumoi, string xacnhanmatkhau)
        {
            GetInfo();
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
                if(_passwordHasher.VerifyHashedPassword(taikhoan, taikhoan.MatKhau, matkhaucu)
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
                        HttpContext.Session.SetString("taikhoan", "");
                        return RedirectToAction(nameof(Login));
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

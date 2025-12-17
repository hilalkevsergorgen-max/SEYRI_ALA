using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEYRİ_ALA.Data;
using SEYRİ_ALA.Models;
using System.Linq;

namespace SEYRİ_ALA.Controllers
{
    public class AccountController : Controller
    {
        // K1: Hilal'in tasarımını bozmadan veritabanı bağlantısını ekliyoruz
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hilal'in hazırladığı boş form yapıları (Aynen korundu)
        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            // Hilal'in validation (doğrulama) yapısını koruyoruz
            if (!ModelState.IsValid) return View(model);

            // K1: Kayıt Mantığı - Veritabanı kontrolü ve EF Core ile yazma
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ViewBag.Message = "❌ Bu e-posta zaten kayıtlı.";
                return View(model);
            }

            var user = new User
            {
                Email = model.Email,
                PasswordHash = model.Password // Bir sonraki adımda hashing eklenecek
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // K1: Giriş Mantığı - Veritabanından kullanıcıyı doğrulama
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.PasswordHash == model.Password);

            if (user != null)
            {
                // K1: Oturum yönetimi altyapısı buraya gelecek
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "❌ Hatalı giriş bilgileri.";
            return View(model);
        }
    }
}
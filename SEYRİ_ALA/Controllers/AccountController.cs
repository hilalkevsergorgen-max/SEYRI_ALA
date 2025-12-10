using Microsoft.AspNetCore.Mvc;

namespace SEYRİ_ALA.Controllers // Not: Namespace adınız SEYRİ_ALA olmalı
{
    public class AccountController : Controller
    {
        // GET: /Account/Register (Kayıt formunu gösterir)
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Kayıt Ol";
            return View();
        }

        // POST: /Account/Register (Formdan gelen veriyi yakalar)
        [HttpPost]
        [ValidateAntiForgeryToken] // Güvenlik için zorunludur
        public IActionResult Register(string FullName, string Email, string Password, string ConfirmPassword)
        {
            // Şimdilik sadece test için bir mesaj gösteriyoruz.
            ViewBag.Message = $"✅ Başarılı! FullName: {FullName}, E-posta: {Email}. Form gönderildi (UI testi).";

            // Veri işlemeye gerek yok, aynı sayfayı geri dönüyoruz.
            return View();
        }

        // GET: /Account/Login (Giriş formunu gösterir)
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Giriş Yap";
            return View();
        }

        // POST: /Account/Login (Formdan gelen veriyi yakalar)
        [HttpPost]
        [ValidateAntiForgeryToken] // Güvenlik için zorunludur
        public IActionResult Login(string Email, string Password, bool RememberMe)
        {
            // Şimdilik sadece test için bir mesaj gösteriyoruz.
            string status = RememberMe ? "Hatırla aktif" : "Hatırla pasif";
            ViewBag.Message = $"✅ Başarılı! E-posta: {Email}, {status}. Giriş denemesi (UI testi).";

            // Veri işlemeye gerek yok, aynı sayfayı geri dönüyoruz.
            return View();
        }
    }
}
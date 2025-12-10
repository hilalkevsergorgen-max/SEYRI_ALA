using Microsoft.AspNetCore.Mvc;
using SEYRİ_ALA.Models; // ViewModel'ları kullanmak için bu satır zorunludur!

namespace SEYRİ_ALA.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Register (RegisterViewModel'ı View'e boş gönderir)
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        // POST: /Account/Register (Formdan gelen RegisterViewModel'ı alır)
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması
        public IActionResult Register(RegisterViewModel model)
        {
            // ModelState.IsValid: ViewModel'daki [Required] vb. kurallarını kontrol eder.
            if (ModelState.IsValid)
            {
                // Kurallar geçildi, başarılı kayıt işlemi burada yapılır (Sonraki Görevler)
                ViewBag.Message = "✅ Kayıt başarılı! Model geçerli, veri işlenmeye hazır.";
                // return RedirectToAction("Index", "Home"); 
            }
            else
            {
                // Kurallar geçilemedi, form hatalarını göstermek için aynı View'a geri dönülür.
                ViewBag.Message = "❌ HATA! Formda zorunlu alanlar veya format hataları var.";
            }

            return View(model); // Hata durumunda, kullanıcının girdiği veriyi tekrar gönder
        }

        // GET: /Account/Login (LoginViewModel'ı View'e boş gönderir)
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: /Account/Login (Formdan gelen LoginViewModel'ı alır)
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kurallar geçildi, başarılı giriş işlemi burada yapılır (Sonraki Görevler)
                ViewBag.Message = $"✅ Giriş başarılı! E-posta: {model.Email}.";
                // return RedirectToAction("Index", "Home");
            }
            else
            {
                // Kurallar geçilemedi, form hatalarını göstermek için aynı View'a geri dönülür.
                ViewBag.Message = "❌ HATA! Giriş bilgileri eksik veya format hatalı.";
            }

            return View(model);
        }
    }
}
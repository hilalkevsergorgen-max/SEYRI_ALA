using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Veritabanı listeleme için şart
using SEYRİ_ALA.Data; // ApplicationDbContext'e erişim için
using SEYRİ_ALA.Models;

namespace SEYRİ_ALA.Controllers
{
    public class HomeController : Controller
    {
        // K1: Veritabanı bağlantısını buraya da enjekte ediyoruz
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Veritabanı kapısını açtık
        }

        // K1 & K2: Şehirleri veritabanından çekip haritaya gönderen Index aksiyonu
        public async Task<IActionResult> Index()
        {
            // Veritabanındaki tüm şehirleri listele
            var cities = await _context.Cities.ToListAsync();

            // Bu şehir listesini haritada işaretçi (marker) oluşturmak için View'a gönderiyoruz
            return View(cities);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

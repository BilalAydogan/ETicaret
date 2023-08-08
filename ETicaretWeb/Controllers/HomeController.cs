using ETicaretWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaretWeb.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() { }    

        public IActionResult Index() => View();
        public IActionResult MusteriHizmetleri() => View();
        public IActionResult Hakkimizda() => View();
        public IActionResult BasindaBiz() => View();
        public IActionResult MagazadanAl() => View();
        public IActionResult KargoBedava() => View();
        public IActionResult Kolayİade() => View();
        public IActionResult TelefonlaSiparis() => View();
        public IActionResult AracaTeslimat() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
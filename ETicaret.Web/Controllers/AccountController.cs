using ETicaret.Web.Code.Rest;
using ETicaret.Web.Code;
using ETicaret.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View();

        public IActionResult GirisYap(LoginModel model)
        {

            UserRestClient client = new UserRestClient();
            dynamic result = client.Login(model.KullaniciAdi, model.Sifre);

            bool success = result.success;

            if (success)
            {
                Repo.Session.KullaniciAd = model.KullaniciAdi;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Rol = (string)result.rol;

                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.LoginError = (string)result.message;
                return View("Login");
            }
        }
    }
}

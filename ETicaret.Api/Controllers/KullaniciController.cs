using ETicaret.Api.Code.Validations;
using ETicaret.Model;
using ETicaret.Model.Views;
using ETicaret.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController
    {
        public KullaniciController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache) { }





        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kullanici item = new Kullanici()
            {
                Id = json.Id,
                KullaniciAdi = json.KullaniciAdi,
                Sifre = json.Sifre,
                RolId = json.RolId,
                KayitTarih = json.KayitTarih,
                GuncellemeTarih = json.GuncellemeTarih,
                EmailOnay = json.EmailOnay,
                EmailOnayTarih = json.EmailOnayTarih,
                Aktif = json.Aktif,
            };
            if (item.Id > 0)
            {
                repo.KullaniciRepository.Update(item);
            }
            else
            {
                repo.KullaniciRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [Authorize("Admin,Personel,MusteriTemsilcisi")]
        [HttpGet("AktifKullanicilar")]
        public dynamic AktifKullanicilar()
        {
            List<V_AktifKullanicilar> items = repo.KullaniciRepository.AktifKullanicilariGetir();
            return new
            {
                success = true,
                data = items
            };
        }
        [HttpPost("UyeOl")]
        public dynamic UyeOl([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string kullaniciAd = json.KullaniciAdi;
            string sifre = json.Sifre;

            Kullanici item = new Kullanici()
            {
                Aktif = true,
                KullaniciAdi = kullaniciAd,
                Sifre = sifre,
                RolId = Enums.Roller.Musteri
            };

            // Kullanıcı Db'de var mı diye kontrol ediyor
            Kullanici? kullanici = repo.KullaniciRepository.FindByCondition(k => k.KullaniciAdi == item.KullaniciAdi).SingleOrDefault<Kullanici>();
            if (kullanici != null)
            {
                return new
                {
                    success = false,
                    message = "Bu kullanıcı adı zaten kullanılıyor"
                };
            }

            KullaniciValidator validator = new KullaniciValidator();
            validator.ValidateAndThrow(item);
            repo.KullaniciRepository.Create(item);
            repo.SaveChanges();

            return new
            {
                success = true
            };
        }
    }
}

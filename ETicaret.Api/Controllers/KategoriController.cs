using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : BaseController
    {
        
        public KategoriController(RepositoryWrapper repo,IMemoryCache cache) : base(repo,cache) { }

        [HttpGet("TumKategoriler")]
        public dynamic TumKategoriler()
        {
            List<Kategori> items;
            if (!cache.TryGetValue("TumKategoriler", out items))
            {
                items = repo.KategoriRepository.FindAll().ToList<Kategori>();
                cache.Set("TumKategoriler", items, DateTimeOffset.UtcNow.AddHours(1));
            }
            return new
            {
                sucess = true,
                date = items
            };
        }
        [Authorize(Roles = "Admin,Personel")]
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model) {
            dynamic json = JObject.Parse(model.GetRawText());

            Kategori item = new Kategori() { 
                Id= json.Id,
                Ad= json.Ad,
                UstKategoriId = json.UstKategoriId,
                Sira = json.Sira,
                Foto = json.Foto,
                Aktif = json.Aktif 
            };
            if (item.Id > 0)
            {
                repo.KategoriRepository.Update(item);
            }
            else
            {
                repo.KategoriRepository.Create(item);
            }
            repo.SaveChanges();
            cache.Remove("TumKategoriler");
            return new
            {
                success = true
            };
        }
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            Kategori item = repo.KategoriRepository.FindByCondition(a =>a.Id == id).SingleOrDefault<Kategori>();
            return new
            {
                sucess = true,
                date = item
            };
        }
        [HttpGet()]
        public dynamic UstKategoriler()
        {
            List<Kategori> items = repo.KategoriRepository.FindByCondition(a => a.UstKategoriId==null).ToList<Kategori>();
            return new
            {
                sucess = true,
                date = items
            };
        }
        [HttpGet("AltKategoriler/{id}")]
        public dynamic AltKategoriler(int id)
        {
            List<Kategori> items = repo.KategoriRepository.FindByCondition(a => a.UstKategoriId == id).ToList<Kategori>();
            return new
            {
                sucess = true,
                date = items
            };
        }
        [HttpGet("AnaSayfaKategorileri")]
        public dynamic AnaSayfaKategorileri()
        {
            List<Kategori> items = repo.KategoriRepository.AnaSayfaKategorileriniGetir().ToList<Kategori>();
            return new
            {
                sucess = true,
                date = items
            };
        }


    }
}

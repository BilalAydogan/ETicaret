using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : BaseController
    {
        public UrunController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpGet("TumUrunler/{kategoriId}")]
        public dynamic TumUrunler(int kategoriId)
        {
            List<Urun> items = repo.UrunRepository.UrunleriGetir(kategoriId).ToList<Urun>();
            return new
            {
                success = true,
                data = items
            };
        }
        [Authorize(Roles = "Admin,Personel")]
        [HttpDelete("{id}")]
        public dynamic Sil(int id)
        {
            repo.UrunRepository.Sil(id);
            return new
            {
                success = true,
            };
        }
        [Authorize(Roles ="Admin,Personel")]
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model) {
            dynamic json = JObject.Parse(model.GetRawText());

            Urun item = new Urun()
            {
                Id = json.Id,
                Ad = json.Ad,
                Aciklama = json.Aciklama,
                Adet = json.Adet,
                Fiyat = json.Fiyat,
            };
            if (item.Id > 0) 
                repo.UrunRepository.Update(item);
            else
            {
                foreach(var kategoriId in json.Kategoriler){
                    item.UrunKategoriler.Add(new UrunKategori() { KategoriId = kategoriId });
                }
                repo.UrunRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true,
            };
        }
    }
}

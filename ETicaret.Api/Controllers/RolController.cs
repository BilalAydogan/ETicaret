using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
namespace ETicaret.Api.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : BaseController
    {
        
        public RolController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache) { }
        [HttpGet("TumRoller")]
        public dynamic TumRoller()
        {
            List<Rol> items = repo.RolRepository.FindAll().ToList<Rol>();
            return new
            {
                success = true,
                date = items
            };
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model) {
            dynamic Json = JObject.Parse(model.GetRawText());

            Rol item = new Rol()
            {
                Id = Json.Id,
                Ad = Json.Ad

            };
            if(item.Id > 0 )
            {
                repo.RolRepository.Update(item);
            }
            else
            {
                repo.RolRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [HttpDelete("{id}")]
        public dynamic Sil(int id)
        {
            repo.RolRepository.RolSil(id);
            return new
            {
                success = true
            };
        }
    }
}

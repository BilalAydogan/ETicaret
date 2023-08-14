using ETicaret.Model;
using ETicaret.Model.Views;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_KategorilerController : BaseController
    {
        public V_KategorilerController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpGet("TumVKategoriler")]
        public dynamic TumV_Kategoriler()
        {
            List<V_Kategoriler> items = repo.TumKategorilerRepository.FindAll().ToList<V_Kategoriler>();
            return new
            {
                success = true,
                data = items,
            };
        }
    }
}

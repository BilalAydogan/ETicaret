﻿using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Login")]
        public dynamic Getir([FromBody] dynamic model)
        {
            dynamic Json = JObject.Parse(model.GetRawText());
            string kullaniciAd = Json.KulaniciAdi;
            string sifre = Json.Sifre;
            Kullanici item = repo.KullaniciRepository.FindByCondition(k => k.KullaniciAdi == kullaniciAd && k.Sifre == sifre).SingleOrDefault<Kullanici>();
            if (item != null)
            {
                Rol rol = repo.RolRepository.FindByCondition(r=>r.Id==item.RolId).SingleOrDefault<Rol>();
                Dictionary<string,object> claims = new Dictionary<string,object>();

                if(rol != null)
                    claims.Add(ClaimTypes.Role, rol.Ad);


                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes("ETicaretKeyVektorelAhlatciGrupDersi");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new
                {
                    success = true,
                    date = tokenHandler.WriteToken(token)
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Kullanıcı adı veya şifre hatalı"
                };
            }
        }
    }
}
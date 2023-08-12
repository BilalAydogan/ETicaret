using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace ETicaret.Web.Code.Rest
{
    public class UserRestClient
    {

        private string BASE_API_URI = "https://localhost:7130/api";

        public dynamic Login(string kullaniciAdi, string sifre)
        {
            RestClient client = new RestClient(BASE_API_URI, configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));

            RestRequest req = new RestRequest("/Auth/Login", Method.Post);
            req.AddJsonBody(new
            {
                KullaniciAdi = kullaniciAdi,
                Sifre = sifre
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}

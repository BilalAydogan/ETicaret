namespace ETicaret.Web.Code
{
    public class Repo
    {
        public static class Session
        {

            public static string? KullaniciAd
            {
                get
                {
                    string kullaniciAd = (new HttpContextAccessor()).HttpContext.Session.GetString("KullaniciAd");
                    return kullaniciAd;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("KullaniciAd", value);
                }
            }
            public static string? Token
            {
                get
                {
                    string token = (new HttpContextAccessor()).HttpContext.Session.GetString("Token");
                    return token;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Token", value);
                }
            }
            public static string? Rol
            {
                get
                {
                    string rol = (new HttpContextAccessor()).HttpContext.Session.GetString("Rol");
                    return rol;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Rol", value);
                }
            }
        }
    }
}

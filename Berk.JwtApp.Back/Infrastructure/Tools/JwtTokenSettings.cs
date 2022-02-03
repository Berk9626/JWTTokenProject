namespace Berk.JwtApp.Back.Infrastructure.Tools
{
    public class JwtTokenSettings
    {
        /*
          ValidAudience = "http://localhost",
        ValidIssuer = "http://localhost",
        ClockSkew = TimeSpan.Zero,//serverla client arasındaki zaman farklılıkları ile ilgili
        ValidateLifetime = true, //tokenın süresini doğrulasın
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yavuzyavuzyavuz1.")), //16 karakterden fazla oluşan bir şey vermek zorundayım.
        ValidateIssuerSigningKey = true,
         
         */



        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "yavuzyavuzyavuz1.";
        public const int Expire = 30; //30 gün geçerli olacak.



    }
}

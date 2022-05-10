using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI.Model.Auth
{
    public class AuthOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int TokenLifeTimeInSeconds { get; set; }
        public SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
    }
}

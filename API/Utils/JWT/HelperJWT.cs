using API.Utils.JWT;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Utils
{
    public class HelperJWT
    {
        private readonly AppSettings _appSettings;

        public HelperJWT(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }

        public string CreateToken(Guid id, string name, string role)
        {
            byte[] key = Encoding.ASCII.GetBytes(this._appSettings.Secret);
            ClaimsIdentity claims = new(new[]
            {
            new Claim("id", id.ToString()),
            new Claim("nombre", name),
            new Claim("rol", role)
        });

            SecurityTokenDescriptor tokenDescription = new()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken createdToken = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}

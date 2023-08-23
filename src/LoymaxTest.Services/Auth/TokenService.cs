using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoymaxTest.Services.Configuration;
using LoymaxTest.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LoymaxTest.Services.Auth
{
    public class TokenService : ITokenService
    {
        #region Private

        private readonly AppSettings _settings;

        /// <summary>
        /// Генерация токена
        /// </summary>
        /// <param name="claims">Claims</param>
        /// <returns>Токен</returns>
        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var duration = _settings.Duration;

            var jwtToken = new JwtSecurityToken(
                "Anyone",
                "Anyone",
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(int.Parse(duration)),
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="settings">AppSettings</param>
        public TokenService(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        /// <summary>
        /// Аутентификация
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="login">Логин</param>
        /// <returns>Токен</returns>
        public AuthToken Authenticate(Guid id, string login)
        {
            var usersClaims = new[]
            {
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };

            var jwtToken = GenerateAccessToken(usersClaims);

            return new AuthToken(jwtToken);
        }
    }
}

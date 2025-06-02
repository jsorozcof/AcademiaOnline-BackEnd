using AcademiaOnline.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcademiaOnline.Infrastructure.Seguridad.TokenSeguridad
{

    public class JwtUtils : IJwtUtils
    {
        private readonly JwtSettings _jwtSettings;
        public JwtUtils(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }
       
        public string GenerateToken(string userId, string fullName, string userName, string email, List<string> roles)
        {

            var key = _jwtSettings.PrivateKey;
             if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("'Secret' not found or empty.");

            var issuer = _jwtSettings.Issuer;
            if (string.IsNullOrWhiteSpace(issuer))
                throw new ArgumentException("'Issuer' not found or empty.");

            var audience = _jwtSettings.Audience;
            if (string.IsNullOrWhiteSpace(audience))
                throw new ArgumentException("'Audience' not found or empty.");

            var expiryMinutes = _jwtSettings.ExpireMinutes.ToString();
            if (string.IsNullOrWhiteSpace(expiryMinutes))
                throw new ArgumentException("'expiryInMinutes' not found or empty.");

           
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, userId),
            new Claim("Name", fullName),
            new Claim("UserId", userId),
        };


            if (roles != null)
            {
                foreach (var rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
            }
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(expiryMinutes)),
                signingCredentials: signingCredentials
                );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedToken;
        }
    }

}

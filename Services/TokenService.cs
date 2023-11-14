using Microsoft.IdentityModel.Tokens;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PracticeAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(CustomerResponseDTO customerResponseDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, customerResponseDTO.Email)
            };

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JwtToken:NotTokenKeyForSureSourceTrustMeDude"]));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                _configuration["JwtToken:Issuer"],
                _configuration["JwtToken:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credential);

            return tokenHandler.WriteToken(token);
        }

        public List<Claim> ReadClaimsFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            if (securityToken == null)
                return new List<Claim>();

            return securityToken.Claims.ToList();
        }
    }
}

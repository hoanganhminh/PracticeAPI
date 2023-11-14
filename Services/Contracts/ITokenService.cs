using PracticeAPI.Models.Data.ResponseDTO;
using System.Security.Claims;

namespace PracticeAPI.Services.Contracts
{
    public interface ITokenService
    {
        public string CreateToken(CustomerResponseDTO customerResponseDTO);
        public List<Claim> ReadClaimsFromToken(string token);
    }
}

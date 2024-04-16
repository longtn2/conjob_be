using ConJob.Domain.DTOs.User;
using System.Security.Claims;

namespace ConJob.Domain.Authentication
{
    
    public interface IJWTHelper
    {
        Task<string> GenerateJWTToken(int id, DateTime expire, UserDTO user);
        Task<string> GenerateJWTRefreshToken(int id, DateTime expire);
        Task<String> GenerateJWTMailAction(int id, DateTime expire, string action);
        ClaimsPrincipal ValidateToken(string jwtToken);
    }
}

using ConJob.Domain.DTOs.User;

namespace ConJob.Domain.Services
{
    public interface IJwtServices
    {
        Task InsertJWTToken(JwtDTO jwt);
        public Task<bool> IsJWTValid(string token);
        public Task InvalidateToken(string token);
    }
}
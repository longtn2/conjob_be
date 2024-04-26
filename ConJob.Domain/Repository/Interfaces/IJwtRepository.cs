using ConJob.Domain.Repository.Interface;
using ConJob.Entities;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IJwtRepository : IGenericRepository<JWTModel>
    {
        public Task<JWTModel?> FindByValue(string token);
        public Task<bool> InvalidToken(string token);
    }
}
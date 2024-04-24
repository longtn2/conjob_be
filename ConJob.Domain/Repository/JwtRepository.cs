using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;

namespace ConJob.Domain.Repository
{
    public class JwtRepository : GenericRepository<JWTModel>, IJwtRepository
    {
        public JwtRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository
{
    public class JwtRepository : GenericRepository<JWTModel>, IJwtRepository
    {
        public JwtRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<JWTModel?> FindByValue(string token)
        {
            return await _context.jwts.FirstOrDefaultAsync(x => x.token_hash_value== token && !x.is_deleted );
        }

        public async Task<bool> InvalidToken(string token)
        {
            try
            {
                var jwt = await _context.jwts.FirstOrDefaultAsync(x => x.token_hash_value == token && !x.is_deleted);
                jwt.is_deleted = true;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return true;
        }
    }
}

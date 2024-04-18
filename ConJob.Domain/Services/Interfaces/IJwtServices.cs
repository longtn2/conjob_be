
using ConJob.Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services
{
    public interface IJwtServices
    {
        Task InsertJWTToken(JwtDTO jwt);
        public Task<bool> IsJWTValid(string token);
        public Task InvalidateToken(string token);
    }
}

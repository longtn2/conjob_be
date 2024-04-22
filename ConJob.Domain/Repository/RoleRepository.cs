using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Constant;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ConJob.Domain.Repository
{
    public class RoleRepository : GenericRepository<RoleModel>, IRoleRepository
    {
        public RoleRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<RoleModel> getRoleByLevel_NameAsync(int level, string roleName)
        {
            return await _context.roles.FirstOrDefaultAsync(r => r.role_name == roleName);
        }

        public async Task<RoleModel> getRoleByNameAsync(string roleName)
        {
            return await _context.roles.FirstOrDefaultAsync(r => r.role_name == roleName);
        }

        public async Task<RoleModel> getRoleExceptAdmin(string roleName)
        {
            return await _context.roles.Where(r => !r.role_name.Equals("admin", StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync(r => r.role_name == roleName);
        }

        public async Task<RoleModel> getRoleByName(string roleName)
        {
            return _context.roles.FirstOrDefault(r => r.role_name == roleName);
        }
    }
}

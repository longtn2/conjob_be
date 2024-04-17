using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository
{
    public class RoleRepository : GenericRepository<RoleModel>, IRoleRepository
    {
        public RoleRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<RoleModel> getRoleByLevel_NameAsync(int level, string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.role_name == roleName);
        }

        public async Task<RoleModel> getRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.role_name == roleName);
        }

        public async Task<RoleModel> getRoleExceptAdmin(string roleName)
        {
            return await _context.Roles.Where(r => !r.role_name.Equals("admin", StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync(r => r.role_name == roleName);
        }

        public async Task<RoleModel> getRoleByNameAsync(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.role_name == roleName);
        }
    }
}

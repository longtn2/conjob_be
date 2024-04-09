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
            return await _context.Role.Where(r => r.RoleAccessLevel == level).FirstOrDefaultAsync(r => r.RoleName == roleName);
        }

        public RoleModel getRoleByName(string roleName)
        {
            return _context.Role.FirstOrDefault(r => r.RoleName == roleName);
        }
    }
}

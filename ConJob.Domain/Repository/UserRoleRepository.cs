using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System.Data.Entity;

namespace ConJob.Domain.Repository
{
    public class UserRoleRepository : GenericRepository<UserRoleModel>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserRoleModel> GetUserRoleAsync(UserModel user, RoleModel role)
        {
            return await _context.UserRoles.Where(x => x.user == user).Where(x => x.role == role).FirstOrDefaultAsync();
        }
    }
}

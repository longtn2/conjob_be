using ConJob.Domain.Repository.Interface;
using ConJob.Entities;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IUserRoleRepository : IGenericRepository<UserRoleModel>
    {
        Task<UserRoleModel> GetUserRoleAsync(UserModel user, RoleModel role);
    }
}

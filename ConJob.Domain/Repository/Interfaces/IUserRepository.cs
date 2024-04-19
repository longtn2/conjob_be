using ConJob.Domain.Repository.Interface;
using ConJob.Entities;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IUserRepository: IGenericRepository<UserModel>
    {
        Task<UserModel> getUserByEmail(string email);
        Task<bool> updateAvatar(string? userid, string avatar);
        Task<bool> changPasswordAsync(string newPassword, UserModel user);
        Task<UserModel> findUserPostAsync(int user_id);
    }
}

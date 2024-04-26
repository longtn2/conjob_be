using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository.Interface;
using ConJob.Entities;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IUserRepository: IGenericRepository<UserModel>
    {
        Task<UserModel> getUserByEmail(string email);
        Task<bool> updateAvatar(string? userid, string avatar);
        Task<bool> changPasswordAsync(string newPassword, UserModel user);
        Task<UserModel> updateAsync(UserInfoDTO userDTO, UserModel userModel);
        Task<UserModel> findUserPostAsync(int user_id);
        Task<UserModel> GetDetailsUserAsync(int id);
        Task<UserModel> GetUserNotIsAdminAsync(int id);
    }
}

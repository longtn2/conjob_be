using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;

namespace ConJob.Domain.Services
{
    public interface IUserServices
    {
        Task<ServiceResponse<UserDTO>> RegisterAsync(UserRegisterDTO user);
        Task<ServiceResponse<UserInfoDTO>> updateUserInfo(UserInfoDTO updateUser, string? id);
        Task<ServiceResponse<UserDetailsDTO>> GetUserInfoAsync(int id);
        Task<ServiceResponse<UserDetailsDTO?>> GetUserByIdAsync(int user_id, int currentUser_id);
        Task<ServiceResponse<UserDTO>> SelectRole(SelectRoleDTO role,string? userid);
        Task<ServiceResponse<object>> changePassword(UPasswordDTO passwordDTO, string? id);
        Task<ServiceResponse<FollowDTO>> followUser(FollowDTO follow);
        Task<ServiceResponse<FollowDTO>> unfollowUser(FollowDTO follow);
    }
}

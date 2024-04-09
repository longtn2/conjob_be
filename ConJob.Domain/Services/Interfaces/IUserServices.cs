using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services
{
    public interface IUserServices
    {
        Task<ServiceResponse<UserDTO>> RegisterAsync(UserRegisterDTO user);
        Task<ServiceResponse<UserDTO>> updateUserInfo(UserInfoDTO updateUser, string? id);
        Task<ServiceResponse<UserInfoDTO>> GetUserInfoAsync(string? id);
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<ServiceResponse<UserDTO>> SelectRole(SelectRoleDTO role,string? userid);
    }
}

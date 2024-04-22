﻿using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Files;
using ConJob.Domain.Response;

namespace ConJob.Domain.Services
{
    public interface IUserServices
    {
        Task<ServiceResponse<UserDTO>> RegisterAsync(UserRegisterDTO user);
        Task<ServiceResponse<UserInfoDTO>> updateUserInfo(UserInfoDTO updateUser, string? id);
        Task<ServiceResponse<UserInfoDTO>> GetUserInfoAsync(string? id);
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<ServiceResponse<UserDTO>> SelectRole(SelectRoleDTO role,string? userid);
        Task<ServiceResponse<object>> changePassword(UPasswordDTO passwordDTO, string? id);
        void updateAvatar(FileDTO fileDTO, string? id);
        Task<ServiceResponse<FollowDTO>> followUser(FollowDTO follow);
        Task<ServiceResponse<FollowDTO>> unfollowUser(FollowDTO follow);
    }
}

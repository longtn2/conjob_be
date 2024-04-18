using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IUserRepository: IGenericRepository<UserModel>
    {
        Task<UserModel> getUserByEmail(string email);
        Task<bool> updateAvatar(string? userid, string avatar);
        Task<bool> changPasswordAsync(string newPassword, UserModel user);
        Task<UserModel> updateAsync(UserInfoDTO userDTO, UserModel userModel);
    }
}

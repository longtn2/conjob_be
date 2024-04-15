using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;
using static ConJob.Domain.Response.EServiceResponseTypes;
using ConJob.Entities;
using ConJob.Data;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.Encryption;
using ConJob.Domain.DTOs.Follow;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ConJob.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _pwHasher;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IFollowRepository _followRepository;
        private readonly AppDbContext _context;

        public UserServices(ILogger<UserServices> logger, IMapper mapper, IPasswordHasher pwhasher, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, AppDbContext context, IFollowRepository followRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _pwHasher = pwhasher;
            _context = context;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _followRepository = followRepository;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            //var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<ServiceResponse<UserInfoDTO>> GetUserInfoAsync(string? id)
        {
            var serviceResponse = new ServiceResponse<UserInfoDTO>();
            var user = _userRepository.GetById(int.Parse(id));
            if (user == null)
            {

                serviceResponse.ResponseType = EResponseType.NotFound;
            }
            else
            {
                UserInfoDTO u = _mapper.Map<UserInfoDTO>(user);
                serviceResponse.Data = u;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDTO>> RegisterAsync(UserRegisterDTO user)
        {
            var serviceResponse = new ServiceResponse<UserDTO>();
            try
            {
                var toAdd = _mapper.Map<UserModel>(user);
                //var role = await _context.Role.FirstOrDefaultAsync(x => x.RoleName == "TimViec");
                var role = _roleRepository.getRoleByName("TimViec");


                if (role == null) ;
                await _context.UserRoles.AddAsync(new UserRoleModel()
                {
                    roles = role,
                    users = toAdd
                });

                //await _context.User!.AddAsync(toAdd);
                await _userRepository.AddAsync(toAdd);
                //await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UserDTO>(toAdd);
            }
            catch (DbUpdateException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Email already taken by another User. Please reset or choose different."+ex.ToString();
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDTO>> SelectRole(SelectRoleDTO Role, string? userid)
        {
            RoleModel selectedRole = await _roleRepository.getRoleExceptAdmin(Role.RoleName);
            var serviceResponse = new ServiceResponse<UserDTO>();

            try
            {
                var userModel = _userRepository.GetById(int.Parse(userid));
                var userRole = _userRoleRepository.GetUserRoleAsync(userModel, selectedRole);
                if (userRole != null)
                {
                    serviceResponse.ResponseType = EResponseType.CannotUpdate;
                    serviceResponse.Message = "You have this role already.";
                }
                else
                {
                    await _userRoleRepository.AddAsync(new UserRoleModel()
                    {
                        roles = selectedRole,
                        users = userModel
                    });
                    serviceResponse.Data = _mapper.Map<UserDTO>(userModel);
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotUpdate;
                serviceResponse.Message = "Something wrong.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDTO>> updateUserInfo(UserInfoDTO updateUser, string? id)
        {

            var serviceResponse = new ServiceResponse<UserDTO>();


            try
            {

                var user = _userRepository.GetById(int.Parse(id));
                if (user == null)
                {

                    serviceResponse.ResponseType = EResponseType.NotFound;
                }
                else
                {
                    user = _mapper.Map(updateUser, user);
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Update User Successful";
                    serviceResponse.Data = _mapper.Map<UserDTO>(user);
                }
            }
            catch (DbUpdateException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotUpdate;
                serviceResponse.Message = "Error Occur While updating data.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> changePassword(UPasswordDTO passwordDTO, string? id)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var userModel = _userRepository.GetById(int.Parse(id));
                var checkPassword = _pwHasher.verify(passwordDTO.oldPassword, userModel.password);
                if (checkPassword)
                {
                    await _userRepository.changPasswordAsync(_pwHasher.Hash(passwordDTO.newPassword), userModel);
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.CannotUpdate;
                    serviceResponse.Message = "Wrong old password.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotUpdate;
                serviceResponse.Message = "Something wrong.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FollowDTO>> followUser(FollowDTO follow)
        {
            var serviceResponse = new ServiceResponse<FollowDTO>();
            try
            {
                var tofollow = _mapper.Map<FollowModel>(follow);
                tofollow.from_user_follows = _userRepository.GetById(tofollow.from_user_id)!;
                tofollow.to_user_follows = _userRepository.GetById(tofollow.to_user_id)!;
                var checkfollow = await _context.Follows.Where(e => e.to_user_follows.id == tofollow.to_user_follows.id && e.from_user_follows.id == tofollow.from_user_follows.id).FirstOrDefaultAsync();
                if (tofollow.to_user_follows == null || tofollow.from_user_follows == null)
                    serviceResponse.ResponseType = EResponseType.BadRequest;
                else if (checkfollow == null)
                {
                    await _followRepository.AddAsync(tofollow);
                    serviceResponse.Data = _mapper.Map<FollowDTO>(tofollow);
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.BadRequest;
                    serviceResponse.Message = "User is followed";
                }
            }
            catch (DbUpdateException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Somthing wrong." + ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FollowDTO>> unfollowUser(FollowDTO follow)
        {
            var serviceResponse = new ServiceResponse<FollowDTO>();
            try
            {
                var toRemove = _mapper.Map<FollowModel>(follow);
                toRemove.from_user_follows = _userRepository.GetById(toRemove.from_user_id)!;
                toRemove.to_user_follows = _userRepository.GetById(toRemove.to_user_id)!;
                /*var result = await _followRepository.GetFollowbyUser(toRemove.FromUser, toRemove.ToUser);*/
                var result = await _context.Follows.Where(e => e.from_user_id == follow.FromUserID && e.to_user_id == follow.ToUserID).FirstOrDefaultAsync();
                if (result == null)
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                }
                else
                {
                    await _followRepository.RemoveAsync(result!);
                    serviceResponse.Data = _mapper.Map<FollowDTO>(toRemove);
                }
            }
            catch (DbUpdateException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Somthing wrong.";
            }
            return serviceResponse;
        }
    }
}

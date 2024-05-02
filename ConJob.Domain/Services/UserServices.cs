using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;
using static ConJob.Domain.Response.EServiceResponseTypes;
using ConJob.Entities;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.Encryption;
using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.Constant;
using Microsoft.AspNetCore.Http;
using ConJob.Domain.DTOs.File;

namespace ConJob.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _pwHasher;
        private readonly IEmailServices _emailServices;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IFollowRepository _followRepository;

        public UserServices(ILogger<UserServices> logger, IMapper mapper, IPasswordHasher pwhasher, IEmailServices emailServices, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IFollowRepository followRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _pwHasher = pwhasher;
            _emailServices = emailServices;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _followRepository = followRepository;
        }

        public async Task<ServiceResponse<UserDetailsDTO?>> GetUserByIdAsync(int user_id, int currentUser_id)
        {
            var serviceResponse = new ServiceResponse<UserDetailsDTO>();
            try
            {
                var user = await _userRepository.GetUserNotIsAdminAsync(user_id);
                if (user == null && currentUser_id != user_id)
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "User Not Found.";
                }
                else
                {
                    serviceResponse = await GetUserInfoAsync(user_id);
                }
            }
            catch (BadHttpRequestException ex)
            {
                throw new BadHttpRequestException(CJConstant.SOMETHING_WENT_WRONG);
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDetailsDTO>> GetUserInfoAsync(int id)
        {
            var serviceResponse = new ServiceResponse<UserDetailsDTO>();
            try
            {
                var user = await _userRepository.GetDetailsUserAsync(id);
                var userInfo = _mapper.Map<UserDetailsDTO>(user);
                serviceResponse.ResponseType = EResponseType.Success;
                serviceResponse.Data = userInfo;
            }
            catch (BadHttpRequestException ex)
            {
                throw new BadHttpRequestException(CJConstant.SOMETHING_WENT_WRONG);
            }
            catch(Exception e) { _logger.LogError(e.Message); throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDTO>> RegisterAsync(UserRegisterDTO user)
        {
            var serviceResponse = new ServiceResponse<UserDTO>();
            try
            {
                var toAdd = _mapper.Map<UserModel>(user);
                var role = await _roleRepository.getRoleByName(CJConstant.JOB_SEEKER);
                await _userRoleRepository.AddAsync(new UserRoleModel()
                {
                    role = role,
                    user = toAdd
                });
                serviceResponse.Data = _mapper.Map<UserDTO>(toAdd);
                serviceResponse.ResponseType = EResponseType.Created;
                serviceResponse.Message = "Register Successfully! Please check your email to confirm account!";
                await _emailServices.sendActivationEmail(toAdd);
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Email already taken by another User. Please reset or choose different.");
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDTO>> SelectRole(SelectRoleDTO Role, string? userid)
        {
            RoleModel selectedRole = await _roleRepository.getRoleExceptAdmin(Role.role_name);
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
                        role = selectedRole,
                        user = userModel
                    });
                    serviceResponse.Data = _mapper.Map<UserDTO>(userModel);
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotUpdate;
                serviceResponse.Message = CJConstant.SOMETHING_WENT_WRONG;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserInfoDTO>> updateUserInfo(UserInfoDTO updateUser, string? id)
        {
            var serviceResponse = new ServiceResponse<UserInfoDTO>();
            try
            {
                var user = _userRepository.GetById(int.Parse(id));
                user = await _userRepository.updateAsync(updateUser, user);
                serviceResponse.ResponseType = EResponseType.Success;
                serviceResponse.Message = "Update user successfully!";
                serviceResponse.Data = _mapper.Map<UserInfoDTO>(user);
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Error Occur While updating data.");
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
                    serviceResponse.Message = "Change password successfully!";
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
                serviceResponse.Message = CJConstant.SOMETHING_WENT_WRONG;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FollowDTO>> followUser(FollowDTO follow)
        {
            var serviceResponse = new ServiceResponse<FollowDTO>();
            try
            {
                var tofollow = _mapper.Map<FollowModel>(follow);
                tofollow.from_user_follow = _userRepository.GetById(tofollow.from_user_id)!;
                tofollow.to_user_follow = _userRepository.GetById(tofollow.to_user_id)!;
                if (follow.ToUserID != follow.FromUserID)
                {
                    var checkfollow = _followRepository.GetFollowbyUser(tofollow.from_user_follow, tofollow.to_user_follow);
                    if (tofollow.to_user_follow == null || tofollow.from_user_follow == null)
                        serviceResponse.ResponseType = EResponseType.BadRequest;
                    else if (checkfollow == null)
                    {
                        await _followRepository.AddAsync(tofollow);
                        serviceResponse.ResponseType = EResponseType.Success;
                        serviceResponse.Message = "Success follow user";
                    }
                    else
                    {
                        serviceResponse.ResponseType = EResponseType.BadRequest;
                        serviceResponse.Message = "User is followed";
                    }
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.BadRequest;
                    serviceResponse.Message = "You can't follow yourself";
                }

            }
            catch
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Something wrong.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FollowDTO>> unfollowUser(FollowDTO follow)
        {
            var serviceResponse = new ServiceResponse<FollowDTO>();
            try
            {
                var toRemove = _mapper.Map<FollowModel>(follow);
                toRemove.from_user_follow = _userRepository.GetById(toRemove.from_user_id)!;
                toRemove.to_user_follow = _userRepository.GetById(toRemove.to_user_id)!;
                if (follow.ToUserID != follow.FromUserID)
                {
                    var result = _followRepository.GetFollowbyUser(toRemove.from_user_follow, toRemove.to_user_follow);
                    if (result == null)
                    {
                        serviceResponse.ResponseType = EResponseType.NotFound;
                    }
                    else
                    {
                        await _followRepository.RemoveAsync(result!);
                        serviceResponse.ResponseType = EResponseType.Success;
                        serviceResponse.Message = "Success follow user";
                    }
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.BadRequest;
                    serviceResponse.Message = "Something wrong";
                }
            }
            catch
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Something wrong.";
            }
            return serviceResponse;
        }
        public async Task updateAvatar(FileDTO fileDTO, string? id)
        {
            try
            {
                await _userRepository.updateAvatar(id, $"{id}/{CJConstant.AVATAR_PATH}/{fileDTO.file_name}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

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
using ConJob.Domain.Files;
using Microsoft.AspNetCore.Http;
using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.Constant;
using ConJob.Data;

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
        private readonly IEmailServices _emailServices;
        private readonly IFollowRepository _followRepository;
        private readonly AppDbContext _context;

        public UserServices(ILogger<UserServices> logger, IMapper mapper, IPasswordHasher pwhasher, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, AppDbContext context, IEmailServices emailServices, IFollowRepository followRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _pwHasher = pwhasher;
            _emailServices = emailServices;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _emailServices = emailServices;
            _followRepository = followRepository;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<ServiceResponse<UserInfoDTO>> GetUserInfoAsync(string? id)
        {
            try
            {
                var serviceResponse = new ServiceResponse<UserInfoDTO>();
                var user = _userRepository.GetById(int.Parse(id));
                UserInfoDTO u = _mapper.Map<UserInfoDTO>(user ?? throw new UnauthorizedAccessException("Unable to obtain data"));
                serviceResponse.Data = u;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ServiceResponse<UserDTO>> RegisterAsync(UserRegisterDTO user)
        {
            var serviceResponse = new ServiceResponse<UserDTO>();
            try
            {
                var toAdd = _mapper.Map<UserModel>(user);
                var role = await _roleRepository.getRoleByName(CJConstant.JOB_SEEKER);
                if (role == null) ;
                await _context.user_roles.AddAsync(new UserRoleModel()
                {
                    role = role,
                    user = toAdd
                });
                await _userRepository.AddAsync(toAdd);
                await _emailServices.sendActivationEmail(toAdd);
                serviceResponse.Data = _mapper.Map<UserDTO>(toAdd);
                serviceResponse.Message = "Registered Successful! Please confirm email in your mailbox.";
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
            RoleModel selectedRole = await _roleRepository.getRoleExceptAdmin(Role.RoleName);
            var serviceResponse = new ServiceResponse<UserDTO>();
            try
            {
                var userModel = _userRepository.GetById(int.Parse(userid));
                var userRole = _userRoleRepository.GetUserRoleAsync(userModel, selectedRole);
                if (userRole != null)
                {
                    throw new BadHttpRequestException("You already have this role.");
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
                throw;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserInfoDTO>> updateUserInfo(UserInfoDTO updateUser, string? id)
        {
            var serviceResponse = new ServiceResponse<UserInfoDTO>();
            try {
                var user = _userRepository.GetById(int.Parse(id));
                if (user == null)
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                }
                else
                {
                    user = await _userRepository.updateAsync(updateUser, user);
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Update user successfully!";
                    serviceResponse.Data = _mapper.Map<UserInfoDTO>(user);
                }
            }
            catch (DbUpdateException ex)
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
                    throw new BadHttpRequestException("Error on change Password! Old password is incorrect!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return serviceResponse;
        }

        public async void updateAvatar(FileDTO fileDTO, string? id)
        {
            try
            {
                var userModel = _userRepository.GetById(int.Parse(id));

                userModel.avatar = $"{userModel.id}/{fileDTO.file_type}/{fileDTO.file_name}";
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ServiceResponse<FollowDTO>> followUser(FollowDTO follow)
        {
            var serviceResponse = new ServiceResponse<FollowDTO>();
            try
            {
                var tofollow = _mapper.Map<FollowModel>(follow);
                tofollow.from_user_follow = _userRepository.GetById(tofollow.from_user_id)!;
                tofollow.to_user_follow = _userRepository.GetById(tofollow.to_user_id)!;

                var checkfollow =  _context.follows.Where(e => e.to_user_follow.id == tofollow.to_user_id && e.from_user_follow.id == tofollow.from_user_id).FirstOrDefault();
                if (tofollow.to_user_follow == null || tofollow.from_user_follow == null)
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
            catch
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Somthing wrong.";
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
                var result = await _context.follows.Where(e => e.from_user_id == follow.FromUserID && e.to_user_id == follow.ToUserID).FirstOrDefaultAsync();
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
            catch
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Somthing wrong.";
            }
            return serviceResponse;
        }
    }
}

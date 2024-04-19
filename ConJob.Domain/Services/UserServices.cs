using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;
using static ConJob.Domain.Response.EServiceResponseTypes;
using ConJob.Entities;
using ConJob.Data;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.Encryption;

namespace ConJob.Domain.Services
{
    public class UserServices :  IUserServices
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _pwHasher;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly AppDbContext _context;

        public UserServices(ILogger<UserServices> logger, IMapper mapper, IPasswordHasher pwhasher, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, AppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _pwHasher = pwhasher;
            _context = context;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
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
                serviceResponse.Message = "User not found";
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
                var role = _roleRepository.getRoleByName("TimViec");
                if (role == null) ;
                await _context.UserRoles.AddAsync(new UserRoleModel()
                {
                    role = role,
                    user = toAdd
                });
                await _userRepository.AddAsync(toAdd);
                serviceResponse.Data = _mapper.Map<UserDTO>(toAdd);
            }
            catch (DbUpdateException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Email already taken by another User. Please reset or choose different.";
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
                        role = selectedRole,
                        user = userModel
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
            try {
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
            } catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotUpdate;
                serviceResponse.Message = "Something wrong.";
            }
            return serviceResponse;
        }

    }
}

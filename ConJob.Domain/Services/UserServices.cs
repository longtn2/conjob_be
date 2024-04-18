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
using ConJob.Domain.Files;
using Microsoft.AspNetCore.Http;

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
        private readonly IEmailServices _emailServices;
        private readonly AppDbContext _context;

        public UserServices(ILogger<UserServices> logger, IMapper mapper, IPasswordHasher pwhasher, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, AppDbContext context, IEmailServices emailServices)
        {
            _logger = logger;
            _mapper = mapper;
            _pwHasher = pwhasher;
            _context = context;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _emailServices = emailServices;
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
                var role = _roleRepository.getRoleByName("TimViec");


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
    }
}

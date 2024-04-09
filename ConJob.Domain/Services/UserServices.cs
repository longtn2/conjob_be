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

namespace ConJob.Domain.Services
{
    public class UserServices :  IUserServices
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly AppDbContext _context;

        public UserServices(ILogger<UserServices> logger, IMapper mapper, IUserRepository userRepository, IRoleRepository roleRepository, AppDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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
                await _context.UserRole.AddAsync(new UserRoleModel()
                {
                    Role = role,
                    User = toAdd
                });

                //await _context.User!.AddAsync(toAdd);
                _userRepository.AddAsync(toAdd);
                //await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UserDTO>(toAdd);
            }
            catch (DbUpdateException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Username/Email already taken by another User. Please reset or choose different.";
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDTO>> SelectRole(SelectRoleDTO Role, string? userid)
        {
            //RoleModel selectedRole = await _context.Role.Where(x=>x.RoleAccessLevel == 1).FirstOrDefaultAsync(x => x.RoleName == Role.RoleName);
            RoleModel selectedRole = await _roleRepository.getRoleByLevel_NameAsync(1, Role.RoleName);
            var serviceResponse = new ServiceResponse<UserDTO>();

            try
            {
                //var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == int.Parse(userid));
                var userModel = (UserModel)_userRepository.Find(x => x.Id == int.Parse(userid));
                if (await _context.UserRole.Where(x => x.User == userModel).Where(x=>x.Role == selectedRole).FirstOrDefaultAsync() != null)
                {
                    serviceResponse.ResponseType = EResponseType.CannotUpdate;
                    serviceResponse.Message = "You have this role already.";
                }
                else
                {
                    await _context.UserRole.AddAsync(new UserRoleModel()
                    {
                        Role = selectedRole,
                        User = userModel
                    });
                    await _context.SaveChangesAsync();
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

        
    }
}

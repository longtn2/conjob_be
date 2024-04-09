using AutoMapper;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ConJob.Domain.DTOs.User;
using Microsoft.AspNetCore.Http;
using ConJob.Domain.Encryption;
using ConJob.Domain.Authentication;
using MailKit;
using ConJob.Domain.DTOs.Authentication;
using static ConJob.Domain.Response.EServiceResponseTypes;
using ConJob.Data;

namespace ConJob.Domain.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _pwHasher;
        private readonly IJWTHelper _jWTHelper;
        private readonly IMapper _mapper;
        private readonly IEmailServices _emailServies;
        private readonly IJwtServices _jwtServices;
        private readonly AppDbContext _context;
        public AuthenticationServices(IUserRepository userRepository, IPasswordHasher pwhasher, IJWTHelper jWTHelper, IMapper mapper, IJwtServices jwtServices, IHttpContextAccessor httpContextAccessor, IEmailServices emailServies, AppDbContext context)
        {
            _userRepository = userRepository;
            _pwHasher = pwhasher;
            _jWTHelper = jWTHelper;
            _mapper = mapper;
            _jwtServices = jwtServices;
            _httpContextAccessor = httpContextAccessor;
            _emailServies = emailServies;
            _context = context;
        }
        public async Task<ServiceResponse<CredentialDTO>> LoginAsync(UserLoginDTO userdata)
        {
            var serviceResponse = new ServiceResponse<CredentialDTO>();
            try
            {
                var user = await _userRepository.getUserByEmail(userdata);
                if (user != null)
                {
                    var checkCredential = _pwHasher.verify(userdata.Password, user.Password);
                    if (checkCredential)
                    {
                        var userDTO = _mapper.Map<UserModel,UserDTO>(user);
                        string? token = await _jWTHelper.GenerateJWTToken(user.Id, DateTime.UtcNow.AddMinutes(10), userDTO);
                        string? refreshToken = await _jWTHelper.GenerateJWTRefreshToken(user.Id, DateTime.UtcNow.AddMonths(6));


                        await _jwtServices.InsertJWTToken(new JwtDTO()
                        {
                            User = user,
                            ExpiredDate = DateTime.UtcNow.AddMonths(6),
                            Token = refreshToken,
                        });

                        serviceResponse.Data = _mapper.Map<CredentialDTO>(user);
                        serviceResponse.Data.RefreshToken = refreshToken;
                        serviceResponse.Data.Token = token;
                    }
                    else
                    {
                        serviceResponse.ResponseType = EResponseType.Unauthorized;
                        serviceResponse.Message = "Login Fail! Wrong password.";

                    }
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.Unauthorized;
                    serviceResponse.Message = "Login Fail! Could not found Account by Username!.";
                }

                return serviceResponse;
            }
            catch
            {

                throw;
            }
        }
        public async Task verifyEmailAsync(string userid)
        {
            var u = await _context.User.FirstOrDefaultAsync(x => x.Id == int.Parse(userid));
            if (u == null || u.IsEmailConfirmed == true)
            {
                return;
            }
            var request = _httpContextAccessor.HttpContext!.Request;
            await _emailServies.sendActivationEmail(u, $"{request.Scheme}://{request.Host}{request.PathBase}");
        }
        public async Task<ServiceResponse<TokenDTO>> refreshTokenAsync(string reftoken)
        {
            var serviceResponse = new ServiceResponse<TokenDTO>();

            var claim = _jWTHelper.ValidateToken(reftoken);

            if (claim.HasClaim(claim => claim.Type == ClaimTypes.NameIdentifier))
            {
                var userid = claim.FindFirst(ClaimTypes.NameIdentifier)!.Value;

                var user = await _context.User.FirstOrDefaultAsync(x => x.Id == int.Parse(userid));
                if (user == null)
                {
                    serviceResponse.ResponseType = EResponseType.Unauthorized;
                    serviceResponse.Message = "Could not found User from token.";
                }
                else
                {

                    var userDTO = _mapper.Map<UserModel, UserDTO>(user);

                    string? token = await _jWTHelper.GenerateJWTToken(user.Id, DateTime.UtcNow.AddMinutes(10), userDTO);

                    if (token == null)
                    {
                        serviceResponse.ResponseType = EResponseType.Unauthorized;
                        serviceResponse.Message = "Could not found User from token.";
                    }
                    else
                    {
                        TokenDTO _tokendto = new TokenDTO();
                        _tokendto.Token = token;
                        serviceResponse.Data = _tokendto;
                    }
                    
                }
            }
            else
            {
                serviceResponse.ResponseType = EResponseType.Unauthorized;
                serviceResponse.Message = "Could not found User from token.";
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<Object>> activeEmailAsync(string Token)
        {
            var serviceResponse = new ServiceResponse<Object>();
            try
            {
               
                var claim = _jWTHelper.ValidateToken(Token);
                var userid = claim.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
                var action = claim.Claims.FirstOrDefault(c => c.Type == "action")!.Value;
                var user = await _context.User.FirstOrDefaultAsync(x=>x.Id == int.Parse(userid));
                if (user == null || action == null || user.IsEmailConfirmed == true) {
                    serviceResponse.ResponseType = EResponseType.Unauthorized;
                    serviceResponse.Message = "Could not found User or activated already.";
                    return serviceResponse;
                }
                if(action == "confirm")
                {
                    user.IsEmailConfirmed = true;
                    _context.Update(user);
                    _context.SaveChanges();
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Activate Success.";
                    
                }
            }
            catch (Exception ex)
            {

            }
            return serviceResponse;
        }
    }
}

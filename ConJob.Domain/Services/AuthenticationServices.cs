﻿using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Authentication;
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _pwHasher;
        private readonly IJWTHelper _jWTHelper;
        private readonly IMapper _mapper;
        private readonly IEmailServices _emailServies;
        private readonly IJwtServices _jwtServices;
        private readonly AppDbContext _context;
        public AuthenticationServices(IUserRepository userRepository, IPasswordHasher pwhasher, IJWTHelper jWTHelper, IMapper mapper, IJwtServices jwtServices, IEmailServices emailServies, AppDbContext context)
        {
            _userRepository = userRepository;
            _pwHasher = pwhasher;
            _jWTHelper = jWTHelper;
            _mapper = mapper;
            _jwtServices = jwtServices;
            _emailServies = emailServies;
            _context = context;
        }

        public async Task<ServiceResponse<CredentialDTO>> LoginAsync(UserLoginDTO userdata)
        {
            var serviceResponse = new ServiceResponse<CredentialDTO>();
            try
            {
                var user = await _userRepository.getUserByEmail(userdata.email);
                if (user != null && _pwHasher.verify(userdata.password, user.password))
                {
                    var userDTO = _mapper.Map<UserModel, UserDTO>(user);
                    string? token = await _jWTHelper.GenerateJWTToken(user.id, DateTime.UtcNow.AddMinutes(10), userDTO);
                    string? refreshToken = await _jWTHelper.GenerateJWTRefreshToken(user.id, DateTime.UtcNow.AddMonths(6));
                    await _jwtServices.InsertJWTToken(new JwtDTO()
                    {
                        user = user,
                        ExpiredDate = DateTime.UtcNow.AddMonths(6),
                        Token = refreshToken,
                    });
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Data = _mapper.Map<CredentialDTO>(user);
                    serviceResponse.Data.RefreshToken = refreshToken;
                    serviceResponse.Data.Token = token;
                }
                else
                {
                    throw new UnauthorizedAccessException("The user or password you entered is incorrect");
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task verifyEmailAsync(string userid)
        {
            var u = _userRepository.GetById(int.Parse(userid));
            if (u == null || u.is_email_confirmed == true)
            {
                return;
            }
            await _emailServies.sendActivationEmail(u);
        }
        public async Task<ServiceResponse<TokenDTO>> refreshTokenAsync(string reftoken)
        {
            try
            {
                var serviceResponse = new ServiceResponse<TokenDTO>();
                if (!await _jwtServices.IsJWTValid(reftoken))
                {
                    throw new UnauthorizedAccessException("Access denied due to invalid credentials. Please verify your login details.");
                }
                var claim = _jWTHelper.ValidateToken(reftoken);
                var userid = claim.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var user = _userRepository.GetById(int.Parse(userid));
                var userDTO = _mapper.Map<UserModel, UserDTO>(user);
                string? token = await _jWTHelper.GenerateJWTToken(user.id, DateTime.UtcNow.AddMinutes(10), userDTO);
                TokenDTO _tokendto = new TokenDTO();
                _tokendto.Token = token;
                serviceResponse.Data = _tokendto;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException("Access denied due to invalid credentials. Please verify your login details.");
            }

        }
        public async Task<ServiceResponse<object>> activeEmailAsync(string Token)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var claim = _jWTHelper.ValidateToken(Token);
                var userid = claim.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
                var action = claim.Claims.FirstOrDefault(c => c.Type == "action")!.Value;
                var user = _userRepository.GetById(int.Parse(userid));
                if (action == "confirm")
                {
                    user.is_email_confirmed = true;
                    _context.Update(user);
                    _context.SaveChanges();
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Activate Success.";
                }
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Invalid Activation link!");
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<object>> sendForgotEmailVerify(string useremail)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var user = await _userRepository.getUserByEmail(useremail);
                await _emailServies.sendForgotPassword(user ?? throw new BadHttpRequestException("Could not found user"));
            }
            catch (Exception e)
            {
                throw;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> logout(string reftoken)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                await _jwtServices.InvalidateToken(reftoken);
                serviceResponse.ResponseType = EResponseType.Success;
                serviceResponse.Message = "Log out successful!";
                return serviceResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

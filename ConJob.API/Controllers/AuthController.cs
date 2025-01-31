﻿
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net;
using System.Security.Claims;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly IUserServices _userServices;
        private readonly IAuthenticationServices _authService;
        public AuthController(ILogger<AuthController> logger, IUserServices userService, IAuthenticationServices authService)
        {
            _logger = logger;
            _userServices = userService;
            _authService = authService;
        }
        
        [Route("/register")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Register(UserRegisterDTO userdata)
        {
            var serviceResponse = await _userServices.RegisterAsync(userdata);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(Register), new { version = "1" }, serviceResponse.Data),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("/login")]
        [Produces("application/json")]
        [HttpPost]
        
        public async Task<ActionResult> Login(UserLoginDTO userdata)
        {
            var serviceResponse = await _authService.LoginAsync(userdata);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(Login), new { version = "1" }, serviceResponse.Data),
                EResponseType.Unauthorized => BadRequest(serviceResponse.Message),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),    
                _ => throw new NotImplementedException()
            };
        }
        [Route("/verify")]
        [Produces("application/json")]
        [HttpPost]
        [Authorize]
        public async Task Verify()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _authService.verifyEmailAsync(userid);
        }

        [Route("/verify/{token}")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> VerifyLink(string token)
        {
            var decode = WebUtility.UrlDecode(token);
            var serviceResponse = await _authService.activeEmailAsync(decode);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Message),
                EResponseType.Unauthorized => BadRequest(serviceResponse.Message),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }
        [Route("/refresh")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> refreshToken(TokenDTO token)
        {
            var serviceResponse = await _authService.refreshTokenAsync(token.Token);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(refreshToken), new { version = "1" }, serviceResponse.Data),
                EResponseType.Unauthorized => BadRequest(serviceResponse.Message),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }
    }
}

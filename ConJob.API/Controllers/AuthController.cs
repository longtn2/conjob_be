﻿
using Asp.Versioning;
using ConJob.API.Error.ValidationError;
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Common;
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
    [ApiVersion("1.0")]
    [ValidateModel]
    [Route("api/v{version:apiVersion}/auth/")]
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userdata"></param>

        /// <response code="201">User registration successful!</response>
        /// <exception cref="NotImplementedException"></exception>
        [Route("register")]
        [Produces("application/json")]
        [HttpPost]
        [ProducesResponseType(typeof(CommonResponseDTO), 201)]
        [ProducesResponseType(typeof(CommonResponseDTO), 400)]
        [ProducesResponseType(typeof(CommonResponseDTO), 500)]
        public async Task<ActionResult> Register(UserRegisterDTO userdata)
        {
           
            var serviceResponse = await _userServices.RegisterAsync(userdata);
            return CreatedAtAction(nameof(Register), new { version = "1" }, serviceResponse.getMessage());

           
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userdata"></param>
        /// <returns></returns>
        /// <response code="200">Login Success!</response>
        /// <response code="401">Login Attemp Fail! Wrong email or password.</response>
        /// <exception cref="NotImplementedException"></exception>
        [ProducesResponseType(typeof(CredentialDTO), 200)]
        [ProducesResponseType(typeof(CommonResponseDTO), 400)]
        [ProducesResponseType(typeof(CommonResponseDTO), 401)]
        [ProducesResponseType(typeof(CommonResponseDTO), 500)]
        [Route("login")]
        [Produces("application/json")]
        [HttpPost]
        
        public async Task<ActionResult> Login(UserLoginDTO userdata)
        {
            var serviceResponse = await _authService.LoginAsync(userdata);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.Unauthorized => BadRequest(serviceResponse.getMessage()),
                EResponseType.BadRequest => BadRequest(serviceResponse.getMessage()),    
                _ => throw new NotImplementedException()
            };
        }

        [Route("verify")]
        [Produces("application/json")]
        [HttpPost]
        [Authorize]
        public async Task Verify()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _authService.verifyEmailAsync(userid);
        }

        [Route("verify/{token}")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> VerifyLink(string token)
        {
            var decode = WebUtility.UrlDecode(token);
            var serviceResponse = await _authService.activeEmailAsync(decode);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.getMessage()),
                EResponseType.Unauthorized => BadRequest(serviceResponse.getMessage()),
                EResponseType.BadRequest => BadRequest(serviceResponse.getMessage()),
                _ => throw new NotImplementedException()
            };
        }
        /// <summary>
        /// To refresh new access token
        /// </summary>
        /// <param name="token">Refresh Token</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [ProducesResponseType(typeof(TokenDTO), 201)]
        [ProducesResponseType(typeof(CommonResponseDTO), 403)]
        [ProducesResponseType(typeof(CommonResponseDTO), 500)]
        [Route("refresh")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> refreshToken(TokenDTO token)
        {
            var serviceResponse = await _authService.refreshTokenAsync(token.Token);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(refreshToken), new { version = "1" }, serviceResponse.Data),
                EResponseType.Unauthorized => BadRequest(serviceResponse.getMessage()),
                EResponseType.BadRequest => BadRequest(serviceResponse.getMessage()),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Send an email to verification Email. To obtain new password.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Route("forgot")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> forgotPassword(string email)
        {

            var serviceResponse = await _authService.sendForgotEmailVerify(email);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.getMessage()),
                EResponseType.BadRequest => BadRequest(serviceResponse.getMessage()),
                _ => throw new NotImplementedException()
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recover"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        [Route("forgot/{token}")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> RecoverPassword(RecoverPasswordDTO recover)
        {
            var decode = WebUtility.UrlDecode(recover.token);
            var serviceResponse = await _authService.RecoverPassword(decode, recover.Password);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.getMessage()),
                EResponseType.Unauthorized => BadRequest(serviceResponse.getMessage()),
                EResponseType.BadRequest => BadRequest(serviceResponse.getMessage()),
                _ => throw new NotImplementedException()
            };
        }
    }
}

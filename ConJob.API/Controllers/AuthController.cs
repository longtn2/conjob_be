
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Common;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using System.Security.Claims;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
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
        [ProducesResponseType(typeof(BadRequestResponseDTO), 400)]
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
        [ProducesResponseType(typeof(CommonResponseDataDTO<CredentialDTO>), 200)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), 400)]
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
                EResponseType.Success => Ok(serviceResponse.getData()),
                EResponseType.Unauthorized => BadRequest(serviceResponse.Message),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),    
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
                EResponseType.Success => Ok(serviceResponse.Message),
                EResponseType.Unauthorized => BadRequest(serviceResponse.Message),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }
        [Route("refresh")]
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
        [Route("forgot")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> forgotPassword(string email)
        {

            var serviceResponse = await _authService.sendForgotEmailVerify(email);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Message),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("logout")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> logout(TokenDTO token)
        {
            var serviceResponse = await _authService.logout(token.Token);
            return Ok(serviceResponse.getMessage());
        }
    }
}

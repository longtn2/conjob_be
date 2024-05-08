using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Common;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Services;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/auth/")]
    public class AuthController : Controller
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly IUserServices _userServices;
        private readonly IAuthenticationServices _authService;
        private readonly IRocketChatServices _rocketChatServices;

        public AuthController(ILogger<AuthController> logger, IUserServices userService, IAuthenticationServices authService, IRocketChatServices rocketChatServices)
        {
            _logger = logger;
            _userServices = userService;
            _authService = authService;
            _rocketChatServices = rocketChatServices;
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
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Created)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        public async Task<ActionResult> Register(UserRegisterDTO userdata)
        {
            var userId = await _rocketChatServices.CreateAccount(userdata);
            var authToken = await _rocketChatServices.CreateAuthToken(userId);
            userdata.rocket_user_id = userId;
            userdata.rocket_auth_token = authToken;
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
        [ProducesResponseType(typeof(CommonResponseDataDTO<CredentialDTO>), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [Route("login")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDTO userdata)
        {
            var serviceResponse = await _authService.LoginAsync(userdata);
            return Ok(serviceResponse.getData());
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
            return Ok(serviceResponse.getMessage());
        }

        [Route("refresh")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> refreshToken(TokenDTO token)
        {
            var serviceResponse = await _authService.refreshTokenAsync(token.Token);
            return CreatedAtAction(nameof(refreshToken), new { version = "1" }, serviceResponse.getData());
        }
        [Route("forgot")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> forgotPassword(string email)
        {

            var serviceResponse = await _authService.sendForgotEmailVerify(email);
            return Ok(serviceResponse.getMessage());
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

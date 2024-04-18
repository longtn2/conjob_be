
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using static ConJob.Domain.Response.EServiceResponseTypes;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Amazon.S3.Transfer;
using Amazon.S3;
using Amazon;
using ConJob.Domain.Services.Interfaces;
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.Response;
using Asp.Versioning;
using ConJob.API.Error.ValidationError;
using ConJob.Domain.Files;

namespace ConJob.API.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion("1.0")]
    [Authorize(Policy = "emailverified")]
    [ApiController]
    [ValidateModel]
    public class UserController : ControllerBase
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly IUserServices _userServices;
        private readonly IS3Services _s3Services;
        public UserController(ILogger<UserController> logger, IUserServices userService, IS3Services s3Services)
        {
            _logger = logger;
            _userServices = userService;
            _s3Services = s3Services;
        }

        [Route("update")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Update(UserInfoDTO userdata)
        {
            var claims = User.Claims.Where(x => x.Type == "UserId").FirstOrDefault();
            string? userid = claims == null ? null : claims.Value.ToString();
            var serviceResponse = await _userServices.updateUserInfo(userdata, userid);
            return Ok(serviceResponse.Data);
        }

        [Route("change-password")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> changePassword(UPasswordDTO passwordDTO)
        {
            var claims = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            string? userid = claims == null ? null : claims.Value.ToString();
            var serviceResponse = await _userServices.changePassword(passwordDTO, userid);
            return Ok(serviceResponse.Data);
        }
        [Route("me")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> get()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _userServices.GetUserInfoAsync(userid);
            return Ok(serviceResponse.Data);
        }
        [Route("upload-avatar")]
        [Produces("application/json")]
        [HttpPost]
        public async Task uploadAvatar(FileDTO file)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var serviceResponse = _s3Services.PresignedUpload(file.file_name, file.file_type, userid);
            _userServices.updateAvatar(file, userid);
        }
    }
}

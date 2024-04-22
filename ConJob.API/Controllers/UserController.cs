using ConJob.Domain.DTOs.User;
using ConJob.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using static ConJob.Domain.Response.EServiceResponseTypes;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ConJob.Domain.Services.Interfaces;
using ConJob.Domain.Response;
using Asp.Versioning;
using ConJob.API.Error.ValidationError;
using ConJob.Domain.Files;
using ConJob.Domain.DTOs.Follow;
using Microsoft.AspNetCore.Authorization;

namespace ConJob.API.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [Asp.Versioning.ApiVersion("1.0")]
    [Authorize(Policy = "emailverified")]
    [ApiController]
    [ValidateModel]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserServices _userServices;
        private readonly IS3Services _s3Services;
        public UserController(ILogger<UserController> logger, IUserServices userService, IS3Services s3Services)
        {
            _logger = logger;
            _userServices = userService;
            _s3Services = s3Services;
        }

        [Route("update-profile")]
        [Produces("application/json")]
        [HttpPost]

        public async Task<ActionResult> updateUserProfile(UserInfoDTO userdata)
        {
            var claims = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
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

        [Route("profile")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> getProfileUser()
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

        [Route("/follow")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> followUser([FromBody] FollowerDTO followUser)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var serviceResponse = await _userServices.followUser(new FollowDTO()
            {
                FromUserID = int.Parse(userid!),
                ToUserID = int.Parse(followUser.toUser)
            });
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                EResponseType.Forbid => Forbid(serviceResponse.Message),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                EResponseType.NotFound => NotFound(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("/unfollow")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> unfollowUser([FromBody] FollowerDTO followUser)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var serviceResponse = await _userServices.unfollowUser(new FollowDTO()
            {
                FromUserID = int.Parse(userid!),
                ToUserID = int.Parse(followUser.toUser),
            });
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                EResponseType.Forbid => Forbid(serviceResponse.Message),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                EResponseType.NotFound => NotFound(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

    }
}
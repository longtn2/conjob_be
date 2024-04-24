using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;
using ConJob.Domain.Services;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{

    [ApiController]
    [Authorize(Policy = "emailverified")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/user/")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserServices _userServices;
        private readonly IS3Services _w3Services;
        public UserController(ILogger<UserController> logger, IUserServices userService, IS3Services w3Services)
        {
            _logger = logger;
            _userServices = userService;
            _w3Services = w3Services;
        }

        [Route("update-profile")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> updateUserProfile(UserInfoDTO userdata)
        {
            var claims = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            string? userid = claims == null ? null : claims.Value.ToString();
            var serviceResponse = await _userServices.updateUserInfo(userdata, userid);
            return Ok(serviceResponse.getMessage());
        }

        [Route("change-password")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> changePassword(UPasswordDTO passwordDTO)
        {
            var claims = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            string? userid = claims == null ? null : claims.Value.ToString();
            var serviceResponse = await _userServices.changePassword(passwordDTO, userid);
            return Ok(serviceResponse.getMessage());
        }

        [Route("profile")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> getProfileUser()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userid == null)
            {
                return BadRequest(new ServiceResponse<UserDetailsDTO> { Message = "User Not Found!", ResponseType = EResponseType.BadRequest});
            }
            else
            {
                var serviceResponse = await _userServices.GetUserInfoAsync(int.Parse(userid));
                return Ok(serviceResponse.getData());
            }
        }

        [Route("info/{id}")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> getUserInfoById(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _userServices.GetUserByIdAsync(id, int.Parse(userid));
            return Ok(serviceResponse);
        }

        [Route("upload-avatar")]
        [Produces("application/json")]
        [HttpPost]
        public async Task uploadAvatar(IFormFile file)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _w3Services.UploadImage(file);
        }

        [Route("follow")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> followUser(int toUserid)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _userServices.followUser(new FollowDTO()
            {
                FromUserID = int.Parse(userid!),
                ToUserID = toUserid
            });
            return Ok(serviceResponse.getMessage());
        }

        [Route("unfollow")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> unfollowUser(int toUserid)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _userServices.unfollowUser(new FollowDTO()
            {
                FromUserID = int.Parse(userid!),
                ToUserID = toUserid,
            });
            return Ok(serviceResponse.getMessage());
        }

    }
}
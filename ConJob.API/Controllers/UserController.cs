using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.Common;
using ConJob.Domain.DTOs.File;
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
        private readonly IS3Services _s3Services;

        public UserController(ILogger<UserController> logger, IUserServices userService, IS3Services s3Services)
        {
            _logger = logger;
            _userServices = userService;
            _s3Services = s3Services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userdata"></param>
        /// <response code="200">Update user profile successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("update-profile")]
        [HttpPut]
        public async Task<ActionResult> updateUserProfile(UserInfoDTO userdata)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _userServices.updateUserInfo(userdata, userid);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passwordDTO"></param>
        /// <response code="200">Change password successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("change-password")]
        [HttpPost]
        public async Task<ActionResult> changePassword(UPasswordDTO passwordDTO)
        {
            var claims = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            string? userid = claims == null ? null : claims.Value.ToString();
            var serviceResponse = await _userServices.changePassword(passwordDTO, userid);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Get profile user successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("profile")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Get user info by id successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("info/{id}")]
        [HttpGet]
        public async Task<ActionResult> getUserInfoById(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _userServices.GetUserByIdAsync(id, int.Parse(userid));
            return Ok(serviceResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <response code="200">Upload avatar successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("upload-avatar")]
        [HttpPost]
        public async Task<ActionResult> uploadAvatar(FileDTO file)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var serviceResponse = _s3Services.PresignedUpload(file.file_name, file.file_type, CJConstant.AVATAR_PATH, userid);
            await _userServices.updateAvatar(file, userid);
            return Ok(serviceResponse.getData());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toUserid"></param>
        /// <response code="200">Follow user successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("follow")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toUserid"></param>
        /// <response code="200">Unfollow user successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("unfollow")]
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
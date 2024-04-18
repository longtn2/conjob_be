
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
using ConJob.Domain.DTOs.Follow;

namespace ConJob.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "emailverified")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly IUserServices _userServices;
        private readonly IS3Services _w3Services;
        public UserController(ILogger<UserController> logger, IUserServices userService, IS3Services w3Services)
        {
            _logger = logger;
            _userServices = userService;
            _w3Services = w3Services;
        }

        [Route("/update")]
        [Produces("application/json")]
        [HttpPost]

        public async Task<ActionResult> Update(UserInfoDTO userdata)
        {
            var claims = User.Claims.Where(x => x.Type == "UserId").FirstOrDefault();
            string? userid = claims == null ? null : claims.Value.ToString();
            var serviceResponse = await _userServices.updateUserInfo(userdata, userid);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.CannotUpdate => BadRequest(serviceResponse.Message),
                EResponseType.Forbid => Forbid(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("/changePassword")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> changePassword(UPasswordDTO passwordDTO)
        {
            var claims = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            string? userid = claims == null ? null : claims.Value.ToString();
            var serviceResponse = await _userServices.changePassword(passwordDTO, userid);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.CannotUpdate => BadRequest(serviceResponse.Message),
                EResponseType.Forbid => Forbid(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("/me")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> get()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _userServices.GetUserInfoAsync(userid);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.NotFound => BadRequest(serviceResponse.Message),
                EResponseType.Forbid => Forbid(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("/avatar/upload")]
        [Produces("application/json")]
        [HttpPost]

        public async Task uploadAvatar(IFormFile file)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _w3Services.UploadImage(file);


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

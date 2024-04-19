using ConJob.Domain.DTOs.User;
using ConJob.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using static ConJob.Domain.Response.EServiceResponseTypes;
using System.Security.Claims;
using ConJob.Domain.Services.Interfaces;
using ConJob.Domain.Response;
using Microsoft.AspNetCore.Authorization;

namespace ConJob.API.Controllers
{

    [ApiController]
    [Authorize(Policy = "emailverified")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
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

        [Route("change-password")]
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

        [Route("profile")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> getProfileUser()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userid == null)
            {
                return BadRequest(new ServiceResponse<UserInfoDTO> { Message = "User Not Found!", ResponseType = EResponseType.BadRequest});
            }
            else
            {
                var serviceResponse = await _userServices.GetUserInfoAsync(userid);
                return serviceResponse.ResponseType switch
                {
                    EResponseType.Success => Ok(serviceResponse.Data),
                    EResponseType.NotFound => BadRequest(serviceResponse.Message),
                    EResponseType.Forbid => Forbid(serviceResponse.Message),
                    _ => throw new NotImplementedException()
                };
            }
        }

        [Route("upload-avatar")]
        [Produces("application/json")]
        [HttpPost]
        public async Task uploadAvatar(IFormFile file)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _w3Services.UploadImage(file);
        }


    }
}

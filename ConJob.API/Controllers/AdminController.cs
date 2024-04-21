using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ConJob.Domain.Response.EServiceResponseTypes;
using System.Security.Claims;
using ConJob.Domain.Filtering;

namespace ConJob.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/")]
    public class AdminController : ControllerBase
    {
        private readonly IPostService _postService;

        public AdminController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("post/delete")]
        [HttpPost]
        public async Task<ActionResult> DeletePost(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.DeleteAsync(int.Parse(userid), id);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse),
                EResponseType.NotFound => NotFound(serviceResponse),
                _ => throw new NotImplementedException()
            };
        }

        [Route("post/active")]
        [HttpPost]
        public async Task<ActionResult> ActivePost(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.ActiveAsync(int.Parse(userid), id);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse),
                EResponseType.NotFound => NotFound(serviceResponse),
                _ => throw new NotImplementedException()
            };
        }

        [Route("post")]
        [HttpGet]
        public async Task<ActionResult> FindUserProjects([FromQuery] FilterOptions? filter, string? statusFilter)
        {
            var serviceResponse = await _postService.FilterAllAsync(filter, statusFilter);
            switch (serviceResponse.ResponseType)
            {
                case EResponseType.Success:
                    Response.Headers.Add("X-Paging-PageNo", serviceResponse.Data?.CurrentPage.ToString());
                    Response.Headers.Add("X-Paging-PageSize", serviceResponse.Data?.PageSize.ToString());
                    Response.Headers.Add("X-Paging-PageCount", serviceResponse.Data?.TotalPages.ToString());
                    Response.Headers.Add("X-Paging-TotalRecordCount", serviceResponse.Data?.TotalCount.ToString());
                    return Ok(serviceResponse.Data?.Items);
                case EResponseType.NotFound:
                    return NotFound(serviceResponse);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

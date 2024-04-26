using ConJob.Domain.Filtering;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConJob.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/v{version:apiVersion}/admin/")]
    public class AdminController : ControllerBase
    {
        private readonly IPostService _postService;

        public AdminController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("post/delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePost(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.DeleteAsync(id);
            return Ok(serviceResponse.getMessage());
        }

        [Route("post/active/{id}")]
        [HttpPut]
        public async Task<ActionResult> ActivePost(int id)
        {
            var serviceResponse = await _postService.ActiveAsync(id);
            return Ok(serviceResponse.getMessage());
        }

        [Route("post")]
        [HttpGet]
        public async Task<ActionResult> FindUserProjects([FromQuery] FilterOptions? filter, string? statusFilter)
        {
            var serviceResponse = await _postService.FilterAllAsync(filter, statusFilter);
            return Ok(serviceResponse.getData());
        }
    }
}

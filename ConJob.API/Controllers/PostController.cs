using ConJob.Domain.DTOs.Common;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.Filtering;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConJob.API.Controllers
{
    [ApiController]
    [Authorize(Policy = "emailverified")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/post/")]
    public class PostController : ControllerBase
    {
        private readonly IReportServices _reportServices;
        private readonly IPostService _postService;
        public PostController(IReportServices reportServices, IPostService postService)
        {
            _reportServices = reportServices;
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult> getAllPosts([FromQuery] FilterOptions? filter)
        {
            var serviceResponse = await _postService.GetAllAsync(filter);
            return Ok(serviceResponse.getData());
        }

        [HttpPost]
        public async Task<ActionResult> addPost(PostDTO newPost)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.SaveAsync(int.Parse(userid), newPost);
            return CreatedAtAction(nameof(addPost), new { version = "1" }, serviceResponse.getMessage());
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> getPostById(int id)
        {
            var serviceResponse = await _postService.FindByIdAsync(id);
            return Ok(serviceResponse.getData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updatePost(int id, PostDTO post)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.UpdateAsync(int.Parse(userid), id, post);
            return Ok(serviceResponse.getMessage());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deletePost(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.DeleteAsync(int.Parse(userid), id);
            return Ok(serviceResponse.getMessage());
        }

        [Route("like")]
        [HttpPost]
        public async Task<ActionResult> likePost(int post_id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.UserLikePost(int.Parse(userid), post_id);
            return Ok(serviceResponse.getMessage());
        }

        [Route("add-job")]
        [HttpPost]
        public async Task<ActionResult> addJobToPost(int job_id, int post_id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.AddJobToPost(int.Parse(userid), job_id, post_id);
            return Ok(serviceResponse.getMessage());
        }

        [Route("report")]
        [HttpPost]
        public async Task<IActionResult> reportPost([FromBody] ReportByUserDTO reportPost)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = new ServiceResponse<ReportByUserDTO>();
            var report = new ReportDTO()
            {
                reason = reportPost.reason,
                post_id = reportPost.post_id,
                user_id = int.Parse(userid!),
            };
            serviceResponse = await _reportServices.reportPost(report);
            return Ok(serviceResponse.getMessage());
        }

        [Route("matching")]
        [HttpGet]
        [ProducesResponseType(typeof(CommonResponseDataDTO<PagingReturnModel<PostDetailsDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> recommendPost([FromQuery]FilterJobs filter)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.suggestPost(int.Parse(userid!), filter);
            return Ok(serviceResponse.getData());
        }
    }
}

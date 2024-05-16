using ConJob.Domain.DTOs.Common;
using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.Filtering;
using ConJob.Domain.Response;
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
    [Route("api/v{version:apiVersion}/post/")]
    public class PostController : ControllerBase
    {
        private readonly IReportServices _reportServices;
        private readonly IPostService _postService;
        private readonly IS3Services _s3Services;
        public PostController(IReportServices reportServices, IPostService postService, IS3Services s3Services)
        {
            _reportServices = reportServices;
            _postService = postService;
            _s3Services = s3Services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <response code="200">Get all post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [HttpGet]
        public async Task<ActionResult> getAllPosts([FromQuery] FilterOptions? filter)
        {
            var serviceResponse = await _postService.GetAllAsync(filter);
            return Ok(serviceResponse.getData());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPost"></param>
        /// <response code="200">Add post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Created)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [HttpPost]
        public async Task<ActionResult> addPost(PostDTO newPost)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = _s3Services.PresignedUpload(newPost.file_name, newPost.file_type, CJConstant.POST_PATH, userid);
            var data = await _postService.SaveAsync(int.Parse(userid), newPost);
            return CreatedAtAction(nameof(addPost), new { version = "1" }, serviceResponse.getData());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Get post by id successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [HttpGet("{id}")]
        public async Task<ActionResult> getPostById(int id)
        {
            var serviceResponse = await _postService.FindByIdAsync(id);
            return Ok(serviceResponse.getData());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <response code="200">Update post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [HttpPut("{id}")]
        public async Task<ActionResult> updatePost(int id, PostDTO post)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.UpdateAsync(int.Parse(userid), id, post);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Delete post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> deletePost(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.DeleteAsync(int.Parse(userid), id);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post_id"></param>
        /// <response code="200">Like post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("like")]
        [HttpPost]
        public async Task<ActionResult> likePost(int post_id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.UserLikePost(int.Parse(userid), post_id);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post_id"></param>
        /// <response code="200">Add job to post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("add-job")]
        [HttpPost]
        public async Task<ActionResult> addJobToPost(int job_id, int post_id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.AddJobToPost(int.Parse(userid), job_id, post_id);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportPost"></param>
        /// <response code="200">Report post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <response code="200">Recommend post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("matching")]
        [HttpGet]
        public async Task<IActionResult> recommendPost([FromQuery]FilterJobs filter)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.suggestPost(int.Parse(userid!), filter);
            return Ok(serviceResponse.getData());
        }
    }
}

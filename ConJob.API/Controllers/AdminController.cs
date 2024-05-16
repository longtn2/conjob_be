using ConJob.Domain.DTOs.Common;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Filtering;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{
    [Authorize(Roles = "Admin", Policy = "emailverified")]
    [ApiController]
    [Route("api/v{version:apiVersion}/admin/")]
    public class AdminController : ControllerBase
    {
        private readonly IPostService _postService;

        public AdminController(IPostService postService)
        {
            _postService = postService;
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
        [Route("post/delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePost(int id)
        {
            var serviceResponse = await _postService.DeleteAsync(id);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Active post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("post/active/{id}")]
        [HttpPut]
        public async Task<ActionResult> ActivePost(int id)
        {
            var serviceResponse = await _postService.ActiveAsync(id);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Undo delete post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("post/undo/{id}")]
        [HttpPut]
        public async Task<ActionResult> UndoDeletedPost(int id)
        {
            var serviceResponse = await _postService.UndoDeletedAsync(id);
            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <response code="200">Filter all post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("post")]
        [HttpGet]
        public async Task<ActionResult> FilterAllPosts([FromQuery] FilterOptions? filter, [FromQuery] DateDTO? date_filter, string? status_filter)
        {
            var user_id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.FilterAllAsync(int.Parse(user_id), filter, date_filter, status_filter);
            return Ok(serviceResponse.getData());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Active all post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("post/active-list")]
        [HttpPut]
        public async Task<ActionResult> ActiveAllPost([FromQuery] List<int> id)
        {
            var serviceResponse = await _postService.ActiveAsync(id);

            return Ok(serviceResponse.getMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Delete all post successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [Route("post/delete-range")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAllPost([FromQuery] List<int> id)
        {
            var serviceResponse = await _postService.DeleteAsync(id);
            return Ok(serviceResponse.getMessage());
        }
    }
}

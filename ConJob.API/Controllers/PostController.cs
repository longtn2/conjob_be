using ConJob.Domain.DTOs.Post;
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
    [Route("api/v{version:apiVersion}/[controller]/")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService) 
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult> getAllPosts(int pageNo)
        {
            var serviceResponse = await _postService.GetAllAsync(pageNo);
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

        [HttpPost]
        public async Task<ActionResult> addPost(PostDTO newPost)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.SaveAsync(int.Parse(userid), newPost);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(addPost), new { version = "1" }, serviceResponse.Data),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("get-user-post/{id}")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> getPostByIdSecurity(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.FindByIdAsync(int.Parse(userid), id);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.NotFound => NotFound(),
                _ => throw new NotImplementedException()
            };
        }

        [Route("get-post/{id}")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> getPostById(int id)
        {
            var serviceResponse = await _postService.FindByIdAsync(id);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.NotFound => NotFound(),
                _ => throw new NotImplementedException()
            };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updatePost(int id, PostDTO post)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.UpdateAsync(int.Parse(userid), id, post);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.NotFound => NotFound(serviceResponse.Message),
                EResponseType.CannotUpdate => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deletePost(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.DeleteAsync(int.Parse(userid), id);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => NoContent(),
                EResponseType.NotFound => NotFound(),
                _ => throw new NotImplementedException()
            };
        }

        [Route("like")]
        [HttpPost]
        public async Task<ActionResult> likePost(int post_id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.UserLikePost(int.Parse(userid), post_id);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("add-job")]
        [HttpPost]
        public async Task<ActionResult> addJobToPost(int job_id, int post_id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.AddJobToPost(int.Parse(userid), job_id, post_id);
            return Ok(serviceResponse.Message);
        }

    }
}

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
        public async Task<ActionResult> GetAllPosts(int pageNo)
        {
            var serviceResponse = await _postService.GetAllAsync(pageNo);
            switch (serviceResponse.ResponseType)
            {
                case EResponseType.Success:
                    return Ok(serviceResponse.Data);
                case EResponseType.NotFound:
                    return NotFound();
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddPost(PostDTO newPost)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.SaveAsync(int.Parse(userid), newPost);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(AddPost), new { version = "1" }, serviceResponse.Data),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [Route("get-user-post/{id}")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> GetPostByIdSecurity(int id)
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
        public async Task<ActionResult> GetPostById(int id)
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
        public async Task<ActionResult> UpdatePost(int id, PostDTO post)
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
        public async Task<ActionResult> DeletePost(int id)
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

    }
}

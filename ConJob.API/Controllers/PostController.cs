using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Filtering;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Security.Claims;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{
    [Authorize(Policy = "emailverified")]
    public class PostController : BaseController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService) 
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult> FindAllPosts(int pageNo)
        {
            var serviceResponse = await _postService.FilterAllAsync(pageNo);
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
            var serviceResponse = await _postService.save(newPost);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(AddPost), new { version = "1" }, serviceResponse.Data),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }
    }
}

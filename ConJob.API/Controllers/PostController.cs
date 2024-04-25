﻿using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IPostService _postService;
        private readonly IReportServices _reportServices;
        public PostController(IReportServices reportServices, IPostService postService)
        {
            _postService = postService;
            _reportServices = reportServices;
        }

        [HttpGet]
        public async Task<ActionResult> getAllPosts(int pageNo)
        {
            var serviceResponse = await _postService.GetAllAsync(pageNo);
            return Ok(serviceResponse.getData());
        }

        [HttpPost]
        public async Task<ActionResult> addPost(PostDTO newPost)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.SaveAsync(int.Parse(userid), newPost);
            return CreatedAtAction(nameof(addPost), new { version = "1" }, serviceResponse.getMessage());
        }

        [Route("get-user-post/{id}")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> getPostByIdSecurity(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = await _postService.FindByIdAsync(int.Parse(userid), id);
            return Ok(serviceResponse.getData());
        }

        [Route("get-post/{id}")]
        [HttpGet]
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

        [HttpPost]
        [Route("report")]
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
    }
}

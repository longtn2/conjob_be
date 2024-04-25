﻿using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.DTOs.Common;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;
using ConJob.Domain.Services;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{
    [ApiController]
    [Authorize(Policy = "emailverified")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ProducesResponseType(typeof(CommonResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommonResponseDTO), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommonResponseDTO), StatusCodes.Status404NotFound)]
    public class ApplicantController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IApplicantService _applicantService;
        public ApplicantController(IUserServices userServices, IApplicantService applicantService)
        {
            _applicantService = applicantService;
            _userServices = userServices;
        }

        [Route("apply")]
        [Produces("application/json")]
        [HttpPost]

        public async Task<IActionResult> applyJob(int job_id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = new ServiceResponse<ApplicantDTO>();
            serviceResponse = await _applicantService.applyJobAsync(int.Parse(userid!), job_id);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(applyJob), new { version = "1" }, serviceResponse.getMessage()),
                EResponseType.NotFound => NotFound(serviceResponse.getMessage()),
                EResponseType.BadRequest => BadRequest(serviceResponse.getMessage()),
                _ => throw new NotImplementedException()
            };
        }
    }
}

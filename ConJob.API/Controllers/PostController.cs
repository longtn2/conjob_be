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
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IReportServices _reportServices;
        public PostController(IReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        [HttpPost]
        [Route("/report")]
        public async Task<IActionResult> reportPost([FromBody]ReportByUserDTO reportPost)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = new ServiceResponse<ReportByUserDTO>();
            var report= new ReportDTO()
            {
                reason= reportPost.reason,
                post_id= reportPost.post_id,
                user_id=int.Parse(userid!),
            };
            serviceResponse = await _reportServices.reportPost(report);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                EResponseType.Forbid => Forbid(serviceResponse.Message),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                EResponseType.NotFound => NotFound(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

    }
}

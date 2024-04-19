using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Filtering;
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
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ServiceResponse<JobDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResponse<JobDTO>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponse<JobDTO>), StatusCodes.Status404NotFound)]
    public class JobController : ControllerBase
    {
        private readonly IJobServices _jobServices;
        public JobController(IJobServices jobServices)
        {
            _jobServices = jobServices;
        }
        [HttpGet("search")]
        public async Task<IActionResult> searchjob([FromQuery] FilterOptions filterOptions)
        {
            var serviceResponse = await _jobServices.searchJobAsync(filterOptions);
            switch (serviceResponse.ResponseType)
            {
                case EResponseType.Success:
                    Response.Headers.Add("X-Paging-PageNo", serviceResponse.Data?.CurrentPage.ToString());
                    Response.Headers.Add("X-Paging-PageSize", serviceResponse.Data?.PageSize.ToString());
                    Response.Headers.Add("X-Paging-PageCount", serviceResponse.Data?.TotalPages.ToString());
                    Response.Headers.Add("X-Paging-TotalRecordCount", serviceResponse.Data?.TotalCount.ToString());
                    return Ok(serviceResponse.Data?.Items);
                case EResponseType.NotFound:
                    return NotFound();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

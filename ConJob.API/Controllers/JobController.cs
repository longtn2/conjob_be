using ConJob.Domain.DTOs.Job;
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
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/job/")]
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
            return Ok(serviceResponse.getData());
        }
        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> get(int id)
        {
            var serviceResponse = new ServiceResponse<JobDetailsDTO>();
            serviceResponse = await _jobServices.GetJobAsync(id);
            return Ok(serviceResponse.getData());
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<JobDTO>>();
            serviceResponse = await _jobServices.GetJobsAsync();
            return Ok(serviceResponse.getData());
        }
        [HttpPost("create")]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] JobDetailsDTO jobDTO)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = new ServiceResponse<JobDetailsDTO>();
            serviceResponse = await _jobServices.AddJobAsync(int.Parse(userid!), jobDTO);
            return Ok(serviceResponse.getMessage());
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JobDTO jobDTO)
        {
            var serviceResponse = new ServiceResponse<JobDTO>();
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            serviceResponse = await _jobServices.UpdateJobAsync(int.Parse(userid!),id, jobDTO);
            return Ok(serviceResponse.getMessage());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<JobDTO>();
            serviceResponse = await _jobServices.DeleteJobAsync(id);
            return Ok(serviceResponse.getMessage());
        }
    }
}

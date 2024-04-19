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
        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> get(int id)
        {
            var serviceResponse = new ServiceResponse<JobDetailsDTO>();
            serviceResponse = await _jobServices.GetJobAsync(id);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse),
                EResponseType.BadRequest => BadRequest(serviceResponse),
                EResponseType.CannotCreate => BadRequest(serviceResponse),
                EResponseType.NotFound => NotFound(serviceResponse),
                _ => throw new NotImplementedException()
            };
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<JobDTO>>();
            serviceResponse = await _jobServices.GetJobsAsync();
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse),
                EResponseType.BadRequest => BadRequest(serviceResponse),
                EResponseType.CannotCreate => BadRequest(serviceResponse),
                EResponseType.NotFound => NotFound(serviceResponse),
                _ => throw new NotImplementedException()
            };
        }
        [HttpPost("create")]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse<JobDetailsDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] JobDetailsDTO jobDTO)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var serviceResponse = new ServiceResponse<JobDetailsDTO>();
            serviceResponse = await _jobServices.AddJobAsync(1, jobDTO);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                EResponseType.NotFound => NotFound(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] JobDTO jobDTO)
        {
            var serviceResponse = new ServiceResponse<JobDTO>();
            serviceResponse = await _jobServices.UpdateJobAsync(int.Parse(id), jobDTO);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                EResponseType.NotFound => NotFound(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }

        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            var serviceResponse = new ServiceResponse<JobDTO>();
            serviceResponse = await _jobServices.DeleteJobAsync(int.Parse(id));
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.BadRequest => BadRequest(serviceResponse.Message),
                EResponseType.CannotCreate => BadRequest(serviceResponse.Message),
                EResponseType.NotFound => NotFound(serviceResponse.Message),
                _ => throw new NotImplementedException()
            };
        }
    }
}

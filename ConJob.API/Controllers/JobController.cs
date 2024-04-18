using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
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
        public async Task<ActionResult<IEnumerable<JobDTO>>> search([FromBody] SearchJob searchJob)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<JobDTO>>();
            serviceResponse = await _jobServices.searchJobAsync(searchJob);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse),
                EResponseType.BadRequest => BadRequest(serviceResponse),
                EResponseType.CannotCreate => BadRequest(serviceResponse),
                EResponseType.NotFound => NotFound(serviceResponse),
                _ => throw new NotImplementedException()
            };
        }
    }
}

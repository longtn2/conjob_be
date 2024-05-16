using ConJob.Data;
using ConJob.Domain.DTOs.Common;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Authorize(Policy = "emailverified")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    public class SkillController : ControllerBase
    {
            private readonly AppDbContext _context;
            private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
           _skillService = skillService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skillDto"></param>
        /// <response code="200">Add skill successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [HttpPost("add-skill")]
        public async Task<IActionResult> AddSkill([FromBody] SkillDTO skillDto)
        {
            try
            {
                var serviceResponse = await _skillService.AddSkill(skillDto);
                return Ok(serviceResponse.getMessage());
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Internal server error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Change skill successful!</response>
        /// <response code="401">Token is invalid or has been expired.</response>
        /// <exception cref="NotImplementedException"></exception>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Success)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)EResponseType.BadRequest)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.InternalError)]
        [ProducesResponseType(typeof(CommonResponseDTO), (int)EResponseType.Unauthorized)]
        [HttpPut("change-skill")]
        public async Task<IActionResult> ChangeSkill(string skillName, [FromBody] ChangeSkillByNameRequest request)
        {
            try
            {
                var serviceResponse = await _skillService.ChangeSkillByNameAsync(skillName, request.NewSkillName, request.NewDescription);
                return Ok(serviceResponse.getMessage());
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Internal server error");
            }
        }

        public class ChangeSkillRequest
        {
            public string NewSkillName { get; set; }
        }

        public class ChangeSkillByNameRequest
        {
            public string NewSkillName { get; set; }
            public string NewDescription { get; set; }

        }
    }
}

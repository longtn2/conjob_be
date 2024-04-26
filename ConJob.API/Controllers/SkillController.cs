using ConJob.Data;
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

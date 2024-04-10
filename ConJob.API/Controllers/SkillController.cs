using Asp.Versioning;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Net.WebSockets;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.API.Controllers
{
    [Route("api/v{version:apiVersion}/skill/")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(Policy = "emailverified", Roles = "TimViec,PhatViec,Admin")]

    public class SkillController : ControllerBase
    {
        private readonly ISkillServices _skillServices;
        public SkillController(ISkillServices skillServices) {
            _skillServices = skillServices;
        }

        [Route("add")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> addSkill(SkillDTO skillDTO)
        {
            var serviceResponse = await _skillServices.addSkill(skillDTO);
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => CreatedAtAction(nameof(addSkill), new { version = "1" }, serviceResponse.getMessage()),
                EResponseType.CannotCreate => BadRequest(serviceResponse.getMessage()),
                _ => throw new NotImplementedException()
            };
        }

        [Route("")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult> getListSkill()
        {
            var serviceResponse = _skillServices.getListSkill();
            return serviceResponse.ResponseType switch
            {
                EResponseType.Success => Ok(serviceResponse.Data),
                EResponseType.CannotCreate => BadRequest(serviceResponse.getMessage()),
                _ => throw new NotImplementedException()
            };
        }


    }
}

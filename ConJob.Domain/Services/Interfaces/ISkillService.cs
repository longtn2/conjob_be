using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface ISkillService
    {
        Task<ServiceResponse<SkillDTO>> AddSkill(SkillDTO skillDto);
        Task<ServiceResponse<SkillDTO>> ChangeSkillByNameAsync(string skillName, string newSkillName, string newDescription);
    }
}

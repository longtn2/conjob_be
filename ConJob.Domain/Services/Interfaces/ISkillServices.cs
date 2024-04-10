using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface ISkillServices
    {
        Task<ServiceResponse<SkillDTO>> addSkill(SkillDTO skill);
        ServiceResponse<IList<SkillDTO>> getListSkill();
        Task<ServiceResponse<Object>> deleteSkillAsync(int skillid);
    }
}

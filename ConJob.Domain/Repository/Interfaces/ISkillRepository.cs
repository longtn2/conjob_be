using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface ISkillRepository
    {
        Task<SkillModel> AddSkill(SkillModel skill);
        IQueryable<SkillModel> FindAll();
        Task<SkillModel> ChangeSkillByNameAsync(string skillName, string newSkillName, string newDescription);
    }
}

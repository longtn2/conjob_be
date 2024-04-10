using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository
{
    public class SkillRepository : GenericRepository<SkillModel>, ISkillRepository
    {
        public SkillRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            
        }
        public IList<SkillModel> getAvailableSkill()
        {
            var skill =  _context.Skill.Where(x => x.isDeleted == false);
            return skill.ToList();

        }
    }
}

using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Services;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _context;
        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SkillModel> AddSkill( SkillModel skill)
        {
            _context.skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }
        public async Task<SkillModel> ChangeSkillByNameAsync(string skillName, string newSkillName, string newDescription)
        {
            var skill = await _context.skills.FirstOrDefaultAsync(s => s.name == skillName);
            if (skill != null)
            {
                skill.name = newSkillName;
                skill.description = newDescription;
                await _context.SaveChangesAsync();
            }
            return skill;
        }
        public IQueryable<SkillModel> FindAll()
        {
            return _context.skills;
        }
    }

}


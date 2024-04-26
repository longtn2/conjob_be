using AutoMapper;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.Filtering;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SkillDTO>> AddSkill(SkillDTO skillDto)
        {
            var serviceResponse = new ServiceResponse<SkillDTO>();
            try
            {
                var skill = _mapper.Map<SkillModel>(skillDto);
                var addskill = await _skillRepository.AddSkill(skill);
                serviceResponse.Data = _mapper.Map<SkillDTO>(skill);
                serviceResponse.ResponseType = EResponseType.Success;
                serviceResponse.Message = "Add post successfully";
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Skill exist in DB");
            }
            catch (Exception e)
            {
                throw;
            }
            return serviceResponse;
        }
        private SkillModel MapDtoToModel(SkillDTO skillDto)
        {
            return new SkillModel
            {
                name = skillDto.name,
                description = skillDto.description,
            };
        }
        public async Task<ServiceResponse<SkillDTO>> ChangeSkillByNameAsync(string skillName, string newSkillName, string newDescription)
        {
            var serviceResponse = new ServiceResponse<SkillDTO>();
            try
            {
                var skill = await _skillRepository.FindAll().FirstOrDefaultAsync(c => c.name == skillName);
                if (skill != null)
                {
                    skill = await _skillRepository.ChangeSkillByNameAsync(skillName, newSkillName, newDescription);
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Update post successfully!";
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "Not Found";
                }
            }
            
            catch { throw; }
            return serviceResponse;
        }
    }
}

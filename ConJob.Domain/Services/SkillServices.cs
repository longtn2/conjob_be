using AutoMapper;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class SkillServices : ISkillServices
    {

        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        public SkillServices(IMapper mapper, ISkillRepository skillRepository) {
            _mapper = mapper;
            _skillRepository = skillRepository;
        
        }
        public async Task<ServiceResponse<SkillDTO>> addSkill(SkillDTO skill)
        {
            var serviceResponse = new ServiceResponse<SkillDTO>();  

            try
            {
                var toAdd = _mapper.Map<SkillModel>(skill);
                await _skillRepository.AddAsync(toAdd);
                serviceResponse.Data = skill;
                serviceResponse.Message = "Add Skill Success";
            }catch (DbUpdateException db)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "An Error Occur";
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<object>> deleteSkillAsync(int skillid)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<IList<SkillDTO>> getListSkill() { 
        
            var serviceResponse = new ServiceResponse<IList<SkillDTO>>();

            try
            {
                var list = _skillRepository.getAvailableSkill();

                serviceResponse.Data = _mapper.Map<IList<SkillDTO>>(list);
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType= EResponseType.NotFound;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


    }
}
